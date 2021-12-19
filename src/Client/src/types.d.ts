interface Request {

}

interface User {
    name: string;
    userName: string;
}

interface AuthResponse {
    token: string;
    user: User;
}