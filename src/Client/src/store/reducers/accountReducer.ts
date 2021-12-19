const { createSlice } = require('@reduxjs/toolkit');

interface AccountState {
   user: null;
   status: 'idle' | 'loading' | 'success' | 'failed';
}

const initialState : AccountState = {
   user: null,
   status: 'idle',
};

const accountSlice = createSlice({
   name: 'account',
   initialState,
   reducers: {},
});

export default accountSlice.reducer;