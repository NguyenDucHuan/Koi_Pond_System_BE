namespace KPCOS.Api.Constants
{
    public class MessageConstant
    {
        public static class LoginConstants
        {
            public const string InvalidUsernameOrPassword = "Tên đăng nhập hoặc mật khẩu không chính xác";
            public const string DeactivatedAccount = "Tài khoản đang bị vô hiệu hoá. Quý khách vui lòng kích hoạt hoặc liên hệ với admin để được hỗ trợ";

        }
        public static class RegisterConstants
        {
            public const string ExistUserName = "Tên tài khoản đã tồn tại";
            public const string PasswordNotMatch = "Mật khẩu không khớp";
            public const string RegisterSuccess = "Đăng ký thành công";
            public const string EmailHaveRegistered = "Email đã được đăng ký";
            public const string RegisterFailed = "Đăng ký thất bại";
        }
        public static class ReGenerationMessage
        {
            public const string InvalidAccessToken = "Access token is invalid.";
            public const string NotExpiredAccessToken = "Access token has not yet expired.";
            public const string NotExistAuthenticationToken = "You do not have the authentication tokens in the system.";
            public const string NotExistRefreshToken = "Refresh token does not exist in the system.";
            public const string NotMatchAccessToken = "Your access token does not match the registered access token.";
            public const string ExpiredRefreshToken = "Refresh token expired.";
        }
    }
}
