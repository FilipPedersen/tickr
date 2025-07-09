using Supabase;

public class SupabaseService
{
    private readonly Client _client;

    public SupabaseService(string url, string key)
    {
        _client = new Client(url, key);
        _client.InitializeAsync().GetAwaiter().GetResult();
    }

    public async Task<Supabase.Gotrue.Session> SignIn(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Email and password must not be empty.");
        }

        var session = await _client.Auth.SignInWithPassword(email, password) ?? throw new InvalidOperationException("Sign in failed: session is null.");
        return session;
    }

    public async Task<Supabase.Gotrue.User> SignUp(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Email and password must not be empty.");
        }

        var session = await _client.Auth.SignUp(email, password);
        if (session == null || session.User == null)
        {
            throw new InvalidOperationException("Sign up failed: session or user is null.");
        }
        return session.User;
    }

    public async Task SignOut()
    {
        await _client.Auth.SignOut();
    }
}