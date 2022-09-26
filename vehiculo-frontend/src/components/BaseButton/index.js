import React from "react";

const BaseButton = ({
  label,
  className,
  onClick,
  type = "button",
  Icon,
  iconClassname,
}) => {
  return (
    <>
      <button
        type={type}
        onClick={onClick}
        className={`${className} inline-flex rounded-md border py-2 px-4 text-sm font-medium shadow-sm  focus:outline-none focus:ring-2  focus:ring-offset-2`}
      >
        {Icon && <Icon className={iconClassname} />}
        {label}
      </button>
    </>
  );
};

export default BaseButton;
