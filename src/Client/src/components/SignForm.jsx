import React, {forwardRef, useImperativeHandle, useRef, useState} from "react";

export const SignForm = forwardRef((props, ref) =>
{
    useImperativeHandle(ref, () =>
    ({
        show() {
            setMode('signIn');
        }
    }));

    const [mode, setMode] = useState('hidden');

    const formRef = useRef();

    const handleClick = () =>
    {
        mode === 'signIn' && setMode('signUp');
        mode === 'signUp' && setMode('signIn');
    }

    const handleHide = (event) =>
    {
        if (!formRef.current.contains(event.target))
        {
            setMode('hidden');
        }
    }

    if (mode === 'hidden')
    {
        return <></>;
    }

    return (
        <div onClick={handleHide} className="bg-gray-900/50 fixed w-full h-full flex flex-col justify-center items-center">
            <div ref={formRef} className="bg-white w-64 p-4 rounded-lg shadow">
                <h1 className="w-full text-center">
                    {mode === 'signIn' && 'Sign in'}
                    {mode === 'signUp' && 'Sign up'}
                </h1>
                {
                    mode === 'signIn' && (
                        <form action="">
                            <div className="mt-4">
                                <input className="w-full outline-none p-2 rounded-lg bg-gray-50 shadow-inner" placeholder="Email" type="text"/>
                            </div>
                            <div className="mt-4">
                                <input className="w-full outline-none p-2 rounded-lg bg-gray-50 shadow-inner" placeholder="Password" type="text"/>
                            </div>
                            <div className="mt-4">
                                <button className="outline-none w-full bg-gray-600 py-2 rounded-lg shadow text-white">Login</button>
                            </div>
                        </form>
                    )
                }
                {
                    mode === 'signUp' && (
                        <form action="">
                            <div className="mt-4">
                                <input className="w-full outline-none p-2 rounded-lg bg-gray-50 shadow-inner" placeholder="Name" type="text"/>
                            </div>
                            <div className="mt-4">
                                <input className="w-full outline-none p-2 rounded-lg bg-gray-50 shadow-inner" placeholder="Email" type="text"/>
                            </div>
                            <div className="mt-4">
                                <input className="w-full outline-none p-2 rounded-lg bg-gray-50 shadow-inner" placeholder="Password" type="text"/>
                            </div>
                            <div className="mt-4">
                                <button className="outline-none w-full bg-gray-600 py-2 rounded-lg shadow text-white">Register</button>
                            </div>
                        </form>
                    )
                }
                <div className="text-center mt-4">
                    <button onClick={handleClick} className="underline text-gray-500">
                        {mode === 'signIn' && 'Create an account'}
                        {mode === 'signUp' && 'Already have an account'}
                    </button>
                </div>
            </div>
        </div>
    );
});