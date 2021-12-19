import React from 'react';

export const TextInputComponent = ({ name, hint }) => {
   return <input name={name} className="border w-64 outline-none bg-gray-100 shadow-inner rounded-lg p-2" placeholder={hint} />;
};
