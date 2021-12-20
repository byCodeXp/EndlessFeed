import React, { useEffect, useRef, useState } from 'react';
import { FormComponent } from './components/base/formComponent';
import { PublishCard } from './components/publishCard';
import { TextInputComponent } from './components/base/textInputComponent';
import { PublishEditor } from './components/publishEditor';
import { AvatarComponent } from './components/base/avatarComponent';
import { useAppDispatch, useAppSelector } from './store/hooks';
import { loadUserAsyncAction, loginAsyncAction, registerAsyncAction } from './store/reducers/account/actions';
import { LoginRequest, RegisterRequest } from './api/services/identityAPI';
import { logoutAction } from './store/reducers/account';
import { tokenUtility } from './utils/tokenUtility';

export const App = () => {
   const dispatch = useAppDispatch();

   const user = useAppSelector((state) => state.account.user);

   const [formMode, setFormMode] = useState<'hidden' | 'login' | 'register'>('hidden');

   const handleClickSignIn = () => {
      setFormMode('login');
   };

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

   const formRef = useRef<HTMLDivElement>(null);

   const handleClickOutsideForm = (event: React.MouseEvent<HTMLDivElement>) => {
      // TODO: on mouse down inside form and release mouse button outside form is closed, fix it

      if (event.target instanceof HTMLElement) {
         if (!formRef.current?.contains(event.target)) {
            setFormMode('hidden');
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

   const handleClickLogout = () => {
      dispatch(logoutAction());
      tokenUtility.clearToken();
   };

   const handleSubmitEditor = (content: string) => {
      console.log(content);
   };

   useEffect(() => {
      dispatch(loadUserAsyncAction());
   }, []);

   useEffect(() => {
      setFormMode('hidden');
   }, [user]);

   return (
      <div className="min-h-full bg-gray-200">
         <div className="container px-8 md:px-12 mx-auto py-4">
            <div className="grid grid-cols-12 gap-y-4">
               <div className="col-span-6 order-1 md:col-span-2 lg:col-span-3 xl:col-span-4 bg-green-300 h-14 flex items-center">
                  <span>Brand Name</span>
               </div>
               <div className="col-span-12 order-3 md:order-2 md:col-span-8 lg:col-span-6 xl:col-span-4 bg-red-300">
                  <PublishEditor onFinish={handleSubmitEditor} />
                  <div className="flex flex-col mt-4 gap-4">
                     <PublishCard />
                     <PublishCard />
                     <PublishCard />
                  </div>
               </div>
               <div className="col-span-6 order-2 md:order-3 md:col-span-2 lg:col-span-3 xl:col-span-4 h-14 flex flex-row-reverse items-center bg-blue-300 relative">
                  {user ? (
                     <div className="relative group">
                        <AvatarComponent src="https://static.toiimg.com/thumb/61319212.cms?width=170&height=240" />
                        <div className="transition opacity-0 -translate-y-1/2 scale-0 group-hover:scale-100 group-hover:translate-y-0 group-hover:opacity-100 absolute left-1/2 -translate-x-1/2">
                           <ul className="bg-white rounded-lg mt-4 shadow-2xl">
                              <li className="cursor-pointer w-24 py-1 text-center hover:bg-gray-100/50">Profile</li>
                              <li className="cursor-pointer w-24 py-1 text-center hover:bg-gray-100/50">Settings</li>
                              <li
                                 onClick={handleClickLogout}
                                 className="cursor-pointer w-24 py-1 text-center hover:bg-gray-100/50"
                              >
                                 Sign out
                              </li>
                           </ul>
                        </div>
                     </div>
                  ) : (
                     <button onClick={handleClickSignIn}>Sign in</button>
                  )}
               </div>
            </div>
         </div>
         {formMode !== 'hidden' && (
            <div
               onClick={handleClickOutsideForm}
               className="fixed top-0 left-0 w-full h-full bg-gray-900/50 flex justify-center items-center"
            >
               <div ref={formRef} className="bg-gray-50 rounded-lg p-8 shadow-2xl">
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
            </div>
         )}
      </div>
   );
};