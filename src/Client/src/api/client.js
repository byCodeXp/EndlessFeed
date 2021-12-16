import axios from "axios";

const BASE_URL = 'https://localhost:5001/api/v1';

function makeAxiosInstance(baseRoute) {
    return axios.create({
        baseURL: `${BASE_URL}/${baseRoute}`
    });
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