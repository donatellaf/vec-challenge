import React from "react";

const BaseTextField = ({ label, disabled = false, register }) => {
  return (
    <>
      <label className="block text-sm font-medium text-gray-700">{label}</label>
      <input
        type="text"
        disabled={disabled}
        {...register}
        className={`mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm ${
          disabled && "bg-gray-300"
        }`}
      />
    </>
  );
};

export default BaseTextField;
