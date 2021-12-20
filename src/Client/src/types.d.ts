interface ApiRequest {

}

interface User {
    id: string;
    name: string;
    surname: string;
    photo: string | null;
    userName: string;
}

interface AuthResponse {
    token: string;
    user: User;
}