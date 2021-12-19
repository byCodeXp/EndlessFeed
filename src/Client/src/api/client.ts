import axios, { AxiosInstance } from 'axios';
import { tokenUtility } from '../utils/tokenUtility';

const BASE_URL = 'https://localhost:5001/api/v1';

function makeAxiosInstance(baseRoute: string) {
   const client = axios.create({
      baseURL: `${BASE_URL}/${baseRoute}`,
   });

   client.interceptors.request.use(
      (config) => {
         const token = tokenUtility.getBearerToken();
         if (token) {
            config.headers = { ...config.headers, Authorization: token };
         }
         return config;
      },
      (error) => Promise.reject(error)
   );

   return client;
}

class Client {
   private client: AxiosInstance;

   constructor(baseRoute: string) {
      this.client = makeAxiosInstance(baseRoute);
   }

   get<TResponse>(url: string) {
      return this.client.get<TResponse>(url);
   }

   post<TResponse>(url: string) {
      return this.client.post<TResponse>(url);
   }

   put<TResponse>(url: string) {
      return this.client.put<TResponse>(url);
   }

   delete<TResponse>(url: string) {
      return this.client.delete<TResponse>(url);
   }
}

export function makeClient(baseRoute: string) {
   return new Client(baseRoute);
}