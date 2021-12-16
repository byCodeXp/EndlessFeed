import axios from "axios";
import {tokenUtility} from "../utils/tokenUtility";

const BASE_URL = 'https://localhost:5001/api/v1';

function makeAxiosInstance(baseRoute) {
    const client = axios.create({
        baseURL: `${BASE_URL}/${baseRoute}`
    });

    client.interceptors.request.use(
        config => {
            const token = tokenUtility.getBearerToken();
            if (token) {
                config.headers = { ...config.headers, Authorization: token }
            }
            return config;
        },
        error => Promise.reject(error)
    );

    return client;
}

class Client
{
    constructor(baseRoute) {
        this._client = makeAxiosInstance(baseRoute);
    }

    get(url) {
        return this._client.get(url);
    }
    post(url, data) {
        return this._client.post(url, data);
    }
    put(url, data) {
        return this._client.put(url, data);
    }
    delete(url) {
        return this._client.delete(url);
    }
}

export function makeClient(baseRoute) {
    return new Client(baseRoute);
}