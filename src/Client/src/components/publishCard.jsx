import React from 'react';

export const PublishCard = () => {
   return (
      <div className="p-4 bg-white rounded-lg shadow">
         <img
            className="rounded-lg shadow"
            src="https://media.wired.com/photos/598e35fb99d76447c4eb1f28/master/pass/phonepicutres-TA.jpg"
         />
         <p className="mt-2 text-gray-800 text-md font-serif">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ex maiores nostrum tempore velit! Ab delectus dignissimos
            et ipsa maxime nam rem? Ad, aliquam aut beatae cum cupiditate, deserunt dolores dolorum eos incidunt iusto
            laudantium minus non nulla optio qui quos sapiente sequi voluptate. Alias atque dolorem et ex facilis, illum labore
            laboriosam nisi nobis nostrum rerum saepe similique sit sunt voluptatibus?
         </p>
         <div className="flex justify-between items-center mt-4">
            <div className="flex items-center gap-3">
               <img
                  className="w-9 h-9 object-cover rounded-full shadow"
                  src="https://static.toiimg.com/thumb/61319212.cms?width=170&height=240"
               />
               <span className="text-gray-700 font-medium">Max Rehkopf</span>
            </div>
            <span className="text-sm text-gray-500">14 Jan 2021</span>
         </div>
      </div>
   );
};