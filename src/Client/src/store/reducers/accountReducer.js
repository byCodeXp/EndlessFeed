const { createSlice } = require("@reduxjs/toolkit");

const initialState = {
    user: undefined,
    status: 'idle'
};

const accountSlice = createSlice({
    name: 'account',
    initialState,
    reducers: {}
});

export default accountSlice.reducer;