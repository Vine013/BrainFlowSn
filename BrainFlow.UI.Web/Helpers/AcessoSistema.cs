using System.Security.Claims;

namespace BrainFlow.UI.Web.Helpers
{
    public static class AcessoSistema
    {
        #region GetUserID           
        /// <summary>
        /// Retorna o ID do usuário logado a partir dos Claims
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int GetUserId(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }
            return 0;
        }
        #endregion

        #region IsAdmin
        /// <summary>
        /// Verifica se o usuário tem o papel de Admin
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsAdmin(ClaimsPrincipal user)
        {
            // O método IsInRole verifica se o usuário possui a 'role'
            return user.IsInRole("Admin");
        }
        #endregion

        #region IsAfiliado
        /// <summary>
        /// Verifica se o usuário tem o papel de Afiliado
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsAfiliado(ClaimsPrincipal user)
        {
            return user.IsInRole("Afiliado");
        }
        #endregion
    }
}
