import React from 'react';

export const FormComponent = ({ onFinish, children }) => {

    const handleSubmitForm = (event) => {
        event.preventDefault();

        const data = new FormData(event.target);

        const result = {};

        for (const [name, value] of data) {
            result[name] = value;
        }

        onFinish(result);
    }

    return <form onSubmit={handleSubmitForm}>{children}</form>;
};