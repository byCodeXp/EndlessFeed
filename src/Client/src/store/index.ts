import { configureStore } from '@reduxjs/toolkit';
import accountReducer from './reducers/accountReducer';

const store = configureStore({
   reducer: {
      account: accountReducer,
   },
});

export default store;