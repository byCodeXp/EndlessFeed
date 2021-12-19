import React, { useRef, useState } from 'react';
import { FormComponent } from './components/base/formComponent';
import { PublishCard } from './components/publishCard';
import {TextInputComponent} from "./components/base/textInputComponent";

export const App = () => {
   const [auth, setAuth] = useState(false);

   const [formMode, setFormMode] = useState('hidden');

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

   const formRef = useRef();

   const handleClickOutsideForm = (event) => {
      if (!formRef.current.contains(event.target)) {
         setFormMode('hidden');
      }
   };

   const handleFinishForm = (values) => {
      setFormMode('hidden');
      setAuth(true);
   };

   const handleClickLogout = () => {
      setAuth(false);
   };

   return (
      <div className="min-h-full bg-gray-200">
         <div className="container px-4 md:px-12 mx-auto py-4">
            <div className="grid grid-cols-12">
               <div className="col-span-12 md:col-span-2 lg:col-span-3 xl:col-span-4 bg-green-300 h-14 flex items-center">
                  <span>Brand Name</span>
               </div>
               <div className="col-span-12 md:col-span-8 lg:col-span-6 xl:col-span-4 bg-red-300">
                  <div className="flex gap-3">
                     <div className="flex-1 bg-purple-300 w-0">
                        <div className="bg-white py-4 px-8 rounded-lg shadow">
                           <label
                              data-value=" "
                              className="block w-full relative after:break-words after:content-[attr(data-value)] after:whitespace-pre-wrap overflow-hidden"
                           >
                              <textarea
                                 className="block absolute min-h-14 h-full resize-none overflow-hidden outline-none w-full max-w-full"
                                 placeholder="Type message here.."
                                 rows={1}
                                 maxLength={512}
                                 onInput={(e) => {
                                    e.target.parentNode.dataset.value = e.target.value + ' ';
                                 }}
                              />
                           </label>
                        </div>
                     </div>
                     <button className="h-14 outline-none p-4 bg-white rounded-lg shadow hover:bg-gray-200 active:bg-gray-300">
                        <div className="h-6 w-6 flex justify-center items-center">
                           <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
                              <path
                                 fillRule="evenodd"
                                 d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z"
                                 clipRule="evenodd"
                              />
                           </svg>
                        </div>
                     </button>
                  </div>
                  <div className="flex flex-col mt-4 gap-4">
                     <PublishCard />
                     <PublishCard />
                     <PublishCard />
                  </div>
               </div>
               <div className="col-span-12 md:col-span-2 lg:col-span-3 xl:col-span-4 h-14 flex flex-row-reverse items-center bg-blue-300 relative">
                  {auth ? (
                     <div className="relative group">
                        <img
                           className="w-10 h-10 object-cover rounded-full shadow"
                           src="https://static.toiimg.com/thumb/61319212.cms?width=170&height=240"
                        />
                        <div className="transition opacity-0 -translate-y-1/2 scale-0 group-hover:scale-100 group-hover:translate-y-0 group-hover:opacity-100 absolute left-1/2 -translate-x-1/2 overflow-hidden">
                           <ul className="bg-white rounded-lg mt-4">
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
                     <FormComponent onFinish={handleFinishForm}>
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
                     <FormComponent onFinish={handleFinishForm}>
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