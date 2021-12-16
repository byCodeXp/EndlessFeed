import React, { useRef } from 'react';
import { TextInput } from './components/TextInput';
import { PublishCard } from './components/PublishCard';
import { UserSection } from './components/UserSection';
import { SignForm } from './components/SignForm';

export const App = () => {
   const handleFinish = (text) => {
      console.log(text);
   };

   const handleSignIn = () => {
      signRef.current.show();
   };

   const signRef = useRef();

   return (
      <div className="flex bg-gray-300 min-h-screen">
         <div className="container mx-auto">
            <div className="my-4 grid grid-cols-12">
               <div className="col-span-12 sm:col-span-12 md:col-span-2 lg:col-span-3 xl:col-span-4">
                  <div className="mt-3 font-medium text-lg text-gray-600">
                     EndlessFeed
                  </div>
               </div>
               <div className="col-span-12 sm:col-span-12 md:col-span-8 lg:col-span-6 xl:col-span-4">
                  <TextInput onFinish={handleFinish} />
                  <div className="col-start-5 col-span-4 space-y-4 mt-4">
                     {Array(3)
                        .fill(null)
                        .map((_) => (
                           <PublishCard />
                        ))}
                  </div>
               </div>
               <div className="col-span-12 sm:col-span-12 md:col-span-2 lg:col-span-3 xl:col-span-4">
                  <div className="flex flex-row-reverse">
                     <UserSection onSign={handleSignIn} />
                  </div>
               </div>
            </div>
         </div>
         <SignForm ref={signRef} />
      </div>
   );
};