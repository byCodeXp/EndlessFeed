import React from 'react';
import { TextInput } from "./components/TextInput";

export const App = () => {

    const handleFinish = (text) => {
        console.log(text);
    }

    return (
        <div className="bg-gray-300 h-full flex justify-center">
            <div style={{width: 640}}>
                <TextInput onFinish={handleFinish} />
            </div>
        </div>
    );
};