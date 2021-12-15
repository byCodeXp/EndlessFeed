import React from 'react';
import {TextInput} from "./components/TextInput";
import {PublishCard} from "./components/PublishCard";

export const App = () => {

    const handleFinish = (text) => {
        console.log(text);
    }

    return (
        <div className="bg-gray-300 min-h-full flex justify-center">
            <div className="py-4" style={{width: 640}}>
                <TextInput onFinish={handleFinish}/>
                <div className="mt-4 space-y-4">
                    {Array(16).fill(null).map(_ => <PublishCard />)}
                </div>
            </div>
        </div>
    );
};