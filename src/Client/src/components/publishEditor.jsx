import React, { useRef } from 'react';

export const PublishEditor = ({ onFinish }) => {
   const textAreaRef = useRef();

   const handleClick = () => {
      onFinish(textAreaRef.current.value);
   };

   return (
      <div className="flex gap-3">
         <div className="flex-1 bg-purple-300 w-0">
            <div className="bg-white py-4 px-8 rounded-lg shadow">
               <label
                  data-value=" "
                  className="block w-full relative after:break-words after:content-[attr(data-value)] after:whitespace-pre-wrap overflow-hidden"
               >
                  <textarea
                     ref={textAreaRef}
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
         <button onClick={handleClick} className="h-14 outline-none p-4 bg-white rounded-lg shadow hover:bg-gray-200 active:bg-gray-300">
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
   );
};