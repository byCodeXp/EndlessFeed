import { createSlice } from '@reduxjs/toolkit';
import { loadUserAsyncAction, loginAsyncAction, registerAsyncAction } from './actions';

interface AccountState {
   user: null;
   status: 'idle' | 'loading' | 'success' | 'failed';
}

const initialState: AccountState = {
   user: null,
   status: 'idle',
};

const accountSlice = createSlice({
   name: 'account',
   initialState,
   reducers: {
      logoutAction: (state) => {
         state.user = null;
         state.status = 'idle';
      },
   },
   extraReducers: {
      // Handle login action
      [loginAsyncAction.pending.type]: (state) => {
         state.status = 'loading';
      },
      [loginAsyncAction.fulfilled.type]: (state, { payload }) => {
         state.user = payload;
         state.status = 'success';
      },
      [loginAsyncAction.rejected.type]: (state, { error }) => {
         state.status = 'failed';
      },
      // Handle register action
      [registerAsyncAction.pending.type]: (state) => {
         state.status = 'loading';
      },
      [registerAsyncAction.fulfilled.type]: (state, { payload }) => {
         state.user = payload;
         state.status = 'success';
      },
      [registerAsyncAction.rejected.type]: (state, { error }) => {
         state.status = 'failed';
      },
      // Handle load user action
      [loadUserAsyncAction.pending.type]: (state) => {
         state.status = 'loading';
      },
      [loadUserAsyncAction.fulfilled.type]: (state, { payload }) => {
         state.user = payload;
         state.status = 'success';
      },
      [loadUserAsyncAction.rejected.type]: (state, { error }) => {
         state.status = 'failed';
      },
   },
});

export default accountSlice.reducer;
export const { logoutAction } = accountSlice.actions;