﻿using System.Threading;
using System.Threading.Tasks;

namespace Firebase.Auth
{

    /// <summary>
    /// The auth token provider.
    /// </summary>
    public interface IFirebaseAuthProvider
    {
        /// <summary>
        /// Creates new user with given credentials.
        /// </summary>
        /// <param name="email"> The email. </param>
        /// <param name="password"> The password. </param>
        /// <param name="displayName"> Optional display name. </param>
        /// <param name="sendVerificationEmail"> Optional. Whether to send user a link to verfiy his email address. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> CreateUserWithEmailAndPasswordAsync(string email, string password, string displayName = "", bool sendVerificationEmail = false, CancellationToken ct = default);

        /// <summary>
        /// Sends user an email with a link to reset his password.
        /// </summary>
        /// <param name="email"> The email.  </param>
        /// <returns> The <see cref="Task"/>. </returns>
        Task SendPasswordResetEmailAsync(string email, CancellationToken ct = default);

        /// <summary>
        /// Sign in user anonymously. He would still have a user id and access token generated, but name and other personal user properties will be null.
        /// </summary>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> SignInAnonymouslyAsync(CancellationToken ct = default);

        /// <summary>
        /// Using the provided email and password, get the firebase auth with token and basic user credentials.
        /// </summary>
        /// <param name="email"> The email. </param>
        /// <param name="password"> The password. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> SignInWithEmailAndPasswordAsync(string email, string password, CancellationToken ct = default);

        /// <summary>
        /// Using the provided access token from third party auth provider (google, facebook...), get the firebase auth with token and basic user credentials.
        /// </summary>
        /// <param name="authType"> The auth type. </param>
        /// <param name="oauthAccessToken"> The access token retrieved from login provider of your choice. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> SignInWithOAuthAsync(FirebaseAuthType authType, string oauthAccessToken, CancellationToken ct = default);

        /// <summary>
        /// Sign in with a custom token. You would usually create and sign such a token on your server to integrate with your existing authentiocation system.
        /// </summary>
        /// <param name="customToken"> The access token retrieved from login provider of your choice. </param>
        /// <returns> The <see cref="FirebaseAuth"/>. </returns>
        Task<FirebaseAuthLink> SignInWithCustomTokenAsync(string customToken, CancellationToken ct = default);

        /// <summary>
        /// Updates profile (displayName and photoUrl) of user tied to given user token.
        /// </summary>
        /// <param name="displayName"> The new display name. </param>
        /// <param name="photoUrl"> The new photo URL. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> UpdateProfileAsync(string firebaseToken, string displayName, string photoUrl, CancellationToken ct = default);

        /// <summary>
        /// Links the authenticated user represented by <see cref="auth"/> with an email and password. 
        /// </summary>
        /// <param name="auth"> The authenticated user to link with specified email and password. </param>
        /// <param name="email"> The email. </param>
        /// <param name="password"> The password. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> LinkAccountsAsync(FirebaseAuth auth, string email, string password, CancellationToken ct = default);

        /// <summary>
        /// Links the authenticated user represented by <see cref="auth"/> with an email and password. 
        /// </summary>
        /// <param name="firebaseToken"> The FirebaseToken (idToken) of an authenticated user. </param>
        /// <param name="email"> The email. </param>
        /// <param name="password"> The password. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> LinkAccountsAsync(string firebaseToken, string email, string password, CancellationToken ct = default);

        /// <summary>
        /// Links the authenticated user represented by <see cref="auth"/> with and account from a third party provider.
        /// </summary>
        /// <param name="auth"> The auth. </param>
        /// <param name="authType"> The auth type.  </param>
        /// <param name="oauthAccessToken"> The access token retrieved from login provider of your choice. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>.  </returns>
        Task<FirebaseAuthLink> LinkAccountsAsync(FirebaseAuth auth, FirebaseAuthType authType, string oauthAccessToken, CancellationToken ct = default);

        /// <summary>
        /// Links the authenticated user represented by <see cref="auth"/> with and account from a third party provider.
        /// </summary>
        /// <param name="firebaseToken"> The FirebaseToken (idToken) of an authenticated user. </param>
        /// <param name="authType"> The auth type.  </param>
        /// <param name="oauthAccessToken"> The access token retrieved from login provider of your choice. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>.  </returns>
        Task<FirebaseAuthLink> LinkAccountsAsync(string firebaseToken, FirebaseAuthType authType, string oauthAccessToken, CancellationToken ct = default);

        /// <summary>
        /// Unlinks the given <see cref="authType"/> from the account associated with <see cref="firebaseToken"/>.
        /// </summary>
        /// <param name="firebaseToken"> The FirebaseToken (idToken) of an authenticated user. </param>
        /// <param name="authType"> The auth type.  </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>.  </returns>
        Task<FirebaseAuthLink> UnlinkAccountsAsync(string firebaseToken, FirebaseAuthType authType, CancellationToken ct = default);

        /// <summary>
        /// Unlinks the given <see cref="authType"/> from the authenticated user represented by <see cref="auth"/>.
        /// </summary>
        /// <param name="auth"> The auth. </param>
        /// <param name="authType"> The auth type.  </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>.  </returns>
        Task<FirebaseAuthLink> UnlinkAccountsAsync(FirebaseAuth auth, FirebaseAuthType authType, CancellationToken ct = default);

        /// <summary>
        /// Gets a list of accounts linked to given email.
        /// </summary>
        /// <param name="email"> Email address. </param>
        /// <returns> The <see cref="ProviderQueryResult"/></returns>
        Task<ProviderQueryResult> GetLinkedAccountsAsync(string email, CancellationToken ct = default);

        /// <summary>
        /// Using the idToken of an authenticated user, get the details of the user's account
        /// </summary>
        /// <param name="firebaseToken"> The FirebaseToken (idToken) of an authenticated user. </param>
        /// <returns> The <see cref="FirebaseUser"/>. </returns>
        Task<FirebaseUser> GetUserAsync(string firebaseToken, CancellationToken ct = default);

        /// <summary>
        /// Using the idToken of an authenticated user, get the details of the user's account
        /// </summary>
        /// <param name="auth"> The authenticated user to verify email address. </param>
        /// <returns> The <see cref="FirebaseUser"/>. </returns>
        Task<FirebaseUser> GetUserAsync(FirebaseAuth auth, CancellationToken ct = default);

        /// <summary>
        /// Sends user an email with a link to verify his email address.
        /// </summary>
        /// <param name="firebaseToken"> The FirebaseToken (idToken) of an authenticated user. </param>
        Task SendEmailVerificationAsync(string firebaseToken, CancellationToken ct = default);

        /// <summary>
        /// Sends user an email with a link to verify his email address.
        /// </summary>
        /// <param name="auth"> The authenticated user to verify email address. </param>
        Task SendEmailVerificationAsync(FirebaseAuth auth, CancellationToken ct = default);

        /// <summary>
        /// Refreshes given auth using its refresh token.
        /// </summary>
        /// <param name="auth"> The authenticated user to have its access token refreshed. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> RefreshAuthAsync(FirebaseAuth auth, CancellationToken ct = default);

        /// <summary>
        ///     Change user's password with his token.
        /// </summary>
        /// <param name="firebaseToken"> The FirebaseToken (idToken) of an authenticated user. </param>
        /// <param name="password"> The new password. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> ChangeUserPasswordAsync(string firebaseToken, string password, CancellationToken ct = default);

        /// <summary>
        /// Using the provided Id token from Twitter signin, get the firebase auth with token and basic user credentials.
        /// </summary>
        /// <param name="oauthAccessToken"> The access token retrieved from twitter. </param>
        /// <param name="oauthAccessToken"> The access token secret supplied by twitter. </param>
        /// <returns> The <see cref="FirebaseAuth"/>. </returns>
        Task<FirebaseAuthLink> SignInWithOAuthTwitterTokenAsync(string oauthAccessToken, string oauthTokenSecret);

        /// <summary>
        /// Deletes the user with a recent Firebase Token.
        /// </summary>
        /// <param name="firebaseToken"> Recent Firebase Token. </param>
        Task DeleteUserAsync(string firebaseToken, CancellationToken ct = default);

        /// <summary>
        ///     Sends user an sms with a code to verify his phone number.
        /// </summary>
        /// <param name="phoneNumber"> Phone number. </param>
        /// <param name="recaptchaToken"> Recaptcha token. </param>
        /// <returns> The session info. </returns>
        Task<string> SendVerificationCodeAsync(string phoneNumber, string recaptchaToken, CancellationToken ct = default);

        /// <summary>
        ///     Using the provided session info and sms code from phone signin, get the firebase auth with token and basic user credentials.
        /// </summary>
        /// <param name="sessionInfo"> Phone verification session info. </param>
        /// <param name="code"> Verification SMS code. </param>
        /// <returns> The <see cref="FirebaseAuthLink"/>. </returns>
        Task<FirebaseAuthLink> SignInWithPhoneAsync(string sessionInfo, string code, CancellationToken ct = default);
    }
}