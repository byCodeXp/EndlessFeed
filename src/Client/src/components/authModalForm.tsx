import React, { useState } from 'react';
import { LoginRequest, RegisterRequest } from '../api/services/identityAPI';
import { useAppDispatch } from '../store/hooks';
import { loginAsyncAction, registerAsyncAction } from '../store/reducers/account/actions';
import { FormComponent } from './base/formComponent';
import { ModalComponent } from './base/modalComponent';
import { TextInputComponent } from './base/textInputComponent';

interface Props {
   visibility: boolean;
   onClickOutsideForm: () => void;
}

export const AuthModalForm = ({ visibility, onClickOutsideForm } : Props) => {
   const dispatch = useAppDispatch();

   const [formMode, setFormMode] = useState<'login' | 'register'>('login');

   const handleChangeFormMode = () => {
      switch (formMode) {
         case 'login': {
            setFormMode('register');
            break;
         }
         case 'register': {
            setFormMode('login');
            break;
         }
      }
   };

   const handleLogin = (values: { [key: string]: string }) => {
      if (values.email && values.password) {
         const request: LoginRequest = {
            email: values.email,
            password: values.password,
         };

         dispatch(loginAsyncAction(request));
      }
   };

   const handleRegister = (values: { [key: string]: string }) => {
      if (values.name && values.email && values.password) {
         const request: RegisterRequest = {
            name: values.name,
            email: values.email,
            password: values.password,
         };

         dispatch(registerAsyncAction(request));
      }
   };

   return (
      <ModalComponent onClickOut={onClickOutsideForm} visibility={visibility}>
         <div className="bg-gray-50 rounded-lg p-8 shadow-2xl">
            <div className="w-full text-center">
               {formMode === 'login' && 'Sign in account'}
               {formMode === 'register' && 'Creating new account'}
            </div>
            {formMode === 'login' && (
               <FormComponent onFinish={handleLogin}>
                  <div className="mt-6">
                     <TextInputComponent name="email" hint="Email" />
                  </div>
                  <div className="mt-6">
                     <TextInputComponent name="password" hint="Password" />
                  </div>
                  <div className="mt-6">
                     <button className="w-64 bg-sky-400 shadow-lg transition-shadow hover:shadow text-white hover:bg-sky-500 p-2 rounded-lg">
                        Login
                     </button>
                  </div>
               </FormComponent>
            )}
            {formMode === 'register' && (
               <FormComponent onFinish={handleRegister}>
                  <div className="mt-6">
                     <TextInputComponent name="name" hint="Name" />
                  </div>
                  <div className="mt-6">
                     <TextInputComponent name="email" hint="Email" />
                  </div>
                  <div className="mt-6">
                     <TextInputComponent name="password" hint="Password" />
                  </div>
                  <div className="mt-6">
                     <button className="w-64 bg-sky-400 shadow-lg transition-shadow hover:shadow text-white hover:bg-sky-500 p-2 rounded-lg">
                        Register
                     </button>
                  </div>
               </FormComponent>
            )}
            <div className="mt-6 text-center">
               <button onClick={handleChangeFormMode} className="underline">
                  {formMode === 'login' && 'Create new account'}
                  {formMode === 'register' && 'Already has an account'}
               </button>
            </div>
         </div>
      </ModalComponent>
   );
};
