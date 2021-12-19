import React from 'react';

interface TextInputComponentProps {
   name: string;
   hint: string;
}

export const TextInputComponent = ({ name, hint } : TextInputComponentProps) => {
   return <input name={name} className="border w-64 outline-none bg-gray-100 shadow-inner rounded-lg p-2" placeholder={hint} />;
};
