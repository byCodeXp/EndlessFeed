import React, {useEffect, useRef, useState} from "react";

export const UserSection = () =>
{
    const dropDownRef = useRef();

    const [expanded, setExpand] = useState(true);

    const handleExpand = () =>
    {
        setExpand(true);
    }

    useEffect(() => {
        window.addEventListener('click', (event) =>
        {
            if (!dropDownRef.current.contains(event.target))
            {
                setExpand(false);
            }
        })
    }, []);

    return (
        <div ref={dropDownRef} className="relative">
            <img onClick={handleExpand} className="cursor-pointer w-11 h-11 object-cover rounded-full shadow" src="http://images4.fanpop.com/image/photos/23000000/Tobey-tobey-maguire-23084591-315-395.jpg"/>
            <div hidden={!expanded} className="bg-white absolute rounded-lg left-1/2 mt-4 -translate-x-2/4 overflow-hidden">
                <ul className="text-gray-500 text-sm text-center font-medium">
                    <li>
                        <a className="block hover:bg-gray-100 px-8 py-2" href="#">Profile</a>
                    </li>
                    <li>
                        <a className="block hover:bg-gray-100 px-8 py-2" href="#">Settings</a>
                    </li>
                    <li>
                        <a className="block hover:bg-gray-100 px-8 py-2" href="#">Logout</a>
                    </li>
                </ul>
            </div>
        </div>
    );
}