import { createAsyncThunk } from '@reduxjs/toolkit';
import { identityAPI, LoginRequest, RegisterRequest } from '../../../api/services/identityAPI';
import { tokenUtility } from '../../../utils/tokenUtility';

export const loginAsyncAction = createAsyncThunk('login_action', async (request: LoginRequest) => {
   try {
      const response = await identityAPI.login(request).then((response) => response.data);
      tokenUtility.setToken(response.token);
      return response.user;
   } catch (error) {
      throw new Error('Something went wrong');
   }
});

export const registerAsyncAction = createAsyncThunk('register_action', async (request: RegisterRequest) => {
   try {
      const response = await identityAPI.register(request).then((response) => response.data);
      tokenUtility.setToken(response.token);
      return response.user;
   } catch (error) {
      throw new Error('Something went wrong');
   }
});

export const loadUserAsyncAction = createAsyncThunk('loadUser_action', async () => {
   try {
      return await identityAPI.getUser().then((response) => response.data);
   } catch (error) {
      throw new Error('Something went wrong');
   }
});