using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Utilisateur.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]

    [ApiVersionNeutral]
    [ApiController]
    public class EtudiantAuthController : ControllerBase
    {
        private readonly BiblioDBContext context;
        private readonly IUtilisateurRepository utilisateurRepository;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

       
        public EtudiantAuthController(BiblioDBContext context, IUtilisateurRepository utilisateurRepository, IMapper mapper, UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.context = context;
            this.utilisateurRepository = utilisateurRepository;
            this.mapper = mapper;
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        [HttpPost]
        [Route("Etudiant Register")]
        public async Task<IActionResult> Create([FromBody] UtilisateurDto utilisateurDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map or Convert DTO to Domain Model
            var utilisateur = mapper.Map<Utilisateur>(utilisateurDto);

            // Use Domain Model to create Utilisateur
            utilisateur = await utilisateurRepository.CreateAsync(utilisateur);

            // Map Domain model back to DTO
            var utilisateurdto = mapper.Map<UtilisateurDto>(utilisateur);

            var identityUser = new IdentityUser
            {
                UserName = utilisateurDto.Email,
                Email = utilisateurDto.Email
            };

            var identityResult = await userManager.CreateAsync(identityUser, utilisateurDto.Password);

            if (identityResult.Succeeded)
            {
                // Add roles to this User
                
                    identityResult = await userManager.AddToRoleAsync(identityUser, "Etudiant");

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login.");
                    }
                
            }

            // Return Created status along with the created resource
            return BadRequest("Something went wrong");


        }
       
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    // Get Roles for this user
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Create Token

                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or password incorrect");
        }
    }
}
