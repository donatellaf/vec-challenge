import { PencilIcon } from "@heroicons/react/24/solid";
import React from "react";

const EditAction = ({ setOpen }) => {
  return (
    <button
      type="button"
      className="inline-flex items-center rounded-md border border-gray-300 bg-white px-2 py-2 text-sm font-medium text-gray-700 shadow-sm hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
      onClick={() => setOpen(true)}
    >
      <PencilIcon className="h-4 w-4 text-gray-500" aria-hidden="true" />
    </button>
  );
};

export default EditAction;
