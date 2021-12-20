import { Action, configureStore, ThunkAction } from '@reduxjs/toolkit';
import accountReducer from './reducers/account';

const store = configureStore({
   reducer: {
      account: accountReducer,
   },
});

export default store;

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<ReturnType, RootState, unknown, Action<string>>;