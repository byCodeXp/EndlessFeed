import React, { useRef } from 'react';

interface Props {
   children: JSX.Element | JSX.Element[];
   onClickOut: () => void;
   visibility: boolean;
}

export const ModalComponent = ({ children, onClickOut, visibility }: Props) => {

   const ref = useRef(null);

   const handleClickOutside = (event: React.MouseEvent<HTMLDivElement>) => {

      // TODO: on mouse down inside form and release mouse button outside form is closed, fix it

      if (ref.current === event.target) {
         onClickOut();
      }
   }

   if (!visibility) {
      return <></>;
   }

   return (
      <div ref={ref} onClick={handleClickOutside} className="fixed top-0 left-0 w-full h-full bg-gray-900/50 flex justify-center items-center">
         {children}
      </div>
   );
};
