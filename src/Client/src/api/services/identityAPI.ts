import { makeClient } from '../client';

// Initialize client with base route

const client = makeClient('identity');


// [POST] - LOGIN REQUEST

export interface LoginRequest extends ApiRequest {
    email: string;
    password: string;
}

const login = (request: LoginRequest) => client.post<AuthResponse>('login', request);

// [POST] - REGISTER REQUEST

export interface RegisterRequest extends ApiRequest {
    name: string;
    email: string;
    password: string;
}

const register = (request: RegisterRequest) => client.post<AuthResponse>('register', request);

// [GET] - USER REQUEST

const getUser = () => client.get<User>('user');

export const identityAPI = { login, register, getUser };