import React from 'react';

interface AvatarComponentProps {
   src: string;
}

export const AvatarComponent = ({ src } : AvatarComponentProps) => {
   return <img className="w-10 h-10 object-cover rounded-full shadow" src={src} />;
};
