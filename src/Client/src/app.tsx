import React, { useEffect, useState } from 'react';
import { PublishCard } from './components/publishCard';
import { PublishEditor } from './components/publishEditor';
import { AvatarComponent } from './components/base/avatarComponent';
import { useAppDispatch, useAppSelector } from './store/hooks';
import { loadUserAsyncAction } from './store/reducers/account/actions';
import { logoutAction } from './store/reducers/account';
import { tokenUtility } from './utils/tokenUtility';
import { AuthModalForm } from './components/authModalForm';

export const App = () => {
   const dispatch = useAppDispatch();

   const user = useAppSelector((state) => state.account.user);

   const [modalFormVisibility, setModalFormVisibility] = useState(false);

   const handleClickLogout = () => {
      dispatch(logoutAction());
      tokenUtility.clearToken();
   };

   const handleSubmitEditor = (content: string) => {
      console.log(content);
   };

   const handleClickSignIn = () => {
      setModalFormVisibility(true);
   };

   const handleClickOutsideForm = () => {
      setModalFormVisibility(false);
   };

   useEffect(() => {
      if (tokenUtility.getToken()) {
         dispatch(loadUserAsyncAction());
      }
   }, []);

   useEffect(() => {
      setModalFormVisibility(false);
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
         <AuthModalForm visibility={modalFormVisibility} onClickOutsideForm={handleClickOutsideForm} />
      </div>
   );
};
