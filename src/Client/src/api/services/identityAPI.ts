import { makeClient } from '../client';

// Initialize client with base route

const client = makeClient('identity');


// [POST] - LOGIN REQUEST

interface LoginCredentials extends Request {
    email: string;
    password: string;
}

const login = (request: LoginCredentials) => client.post<AuthResponse>('login', request);

// [POST] - REGISTER REQUEST

interface RegisterCredentials extends Request {
    name: string;
    email: string;
    password: string;
}

const register = (request: RegisterCredentials) => client.post<AuthResponse>('register', request);

// [GET] - USER REQUEST

const getUser = () => client.get<User>('user');


export const identityAPI = { login, register, getUser };