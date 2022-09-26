import React from "react";

const BaseSelect = ({ label, data, register }) => {
  return (
    <>
      <label className="block text-sm font-medium text-gray-700">{label}</label>
      <select
        {...register}
        className=" capitalize mt-1 block w-full rounded-md border border-gray-300 bg-white py-2 px-3 shadow-sm focus:border-indigo-500 focus:outline-none focus:ring-indigo-500 sm:text-sm"
      >
        {data.map((item) => (
          <option key={item.id} value={item.id}>
            {item.name}
          </option>
        ))}
      </select>
    </>
  );
};

export default BaseSelect;
