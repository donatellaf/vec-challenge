import React from "react";
import EditAction from "./EditAction";
import RemoveAction from "./RemoveAction";

const Actions = (props) => {
  return (
    <div className="flex items-center gap-1">
      <EditAction {...props} />
      <RemoveAction {...props} />
    </div>
  );
};

export default Actions;
