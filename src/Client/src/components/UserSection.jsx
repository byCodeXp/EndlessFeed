import React, { useEffect, useRef, useState } from 'react';

export const UserSection = ({ onSign }) => {
   const dropDownRef = useRef();

   const [expanded, setExpand] = useState(true);

   const handleExpand = () => {
      setExpand(true);
   };

   const handleSignClick = () => {
      onSign();
   };

   useEffect(() => {
      window.addEventListener('click', (event) => {
         if (!dropDownRef.current.contains(event.target)) {
            setExpand(false);
         }
      });
   }, []);

   return (
      <a
         onClick={handleSignClick}
         className="font-medium text-gray-500 mt-3"
         href="#"
      >
         Sign in
      </a>
   );

   return (
      <div ref={dropDownRef} className="relative">
         <img
            onClick={handleExpand}
            className="cursor-pointer w-11 h-11 object-cover rounded-full shadow"
            src="http://images4.fanpop.com/image/photos/23000000/Tobey-tobey-maguire-23084591-315-395.jpg"
         />
         <div
            hidden={!expanded}
            className="bg-white absolute rounded-lg w-36 left-1/2 mt-4 -translate-x-2/4 overflow-hidden"
         >
            <ul className="text-gray-500 text-sm text-center font-medium">
               <li className="py-1 bg-gray-50">@maxrehkopf</li>
               <li>
                  <a className="block hover:bg-gray-100 py-2" href="#">
                     Profile
                  </a>
               </li>
               <li>
                  <a className="block hover:bg-gray-100 py-2" href="#">
                     Settings
                  </a>
               </li>
               <li>
                  <a className="block hover:bg-gray-100 py-2" href="#">
                     Logout
                  </a>
               </li>
            </ul>
         </div>
      </div>
   );
};