import React, { useRef, useState } from 'react';

export const TextInput = ({ onFinish }) =>
{
    const [visible, setVisible] = useState(false);

    const textRef = useRef();

    const handleChange = () =>
    {
        if (textRef.current.textContent.length > 0)
        {
            setVisible(true)
        }
        else
        {
            setVisible(false)
        }
    }

    const handleClick = () =>
    {
        onFinish(textRef.current.textContent);
    }

    return (
        <div className="flex gap-3">
            <div className="relative flex-1">
                <div ref={textRef} onKeyUp={handleChange} className="absolute overflow-auto shadow bg-white py-4 rounded-lg px-8 outline-none w-full" contentEditable />
                <span hidden={visible} className="pointer-events-none absolute py-4 px-8 text-gray-400">Type message here</span>
            </div>
            <button onClick={handleClick} className="outline-none shadow w-16 bg-white rounded-lg py-4 hover:bg-gray-100 active:bg-gray-200">
                <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6 m-auto" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M14 5l7 7m0 0l-7 7m7-7H3" />
                </svg>
            </button>
        </div>
    );
};