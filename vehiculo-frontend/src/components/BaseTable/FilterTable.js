import React from "react";
import { useAsyncDebounce } from "react-table";

function GlobalFilter({
  preGlobalFilteredRows,
  globalFilter,
  setGlobalFilter,
}) {
  const count = preGlobalFilteredRows.length;
  const [value, setValue] = React.useState(globalFilter);
  const onChange = useAsyncDebounce((value) => {
    setGlobalFilter(value || undefined);
  }, 200);

  return (
    <label className="flex gap-x-2 items-baseline ">
      <span className="text-gray-700">Buscar: </span>
      <input
        type="text"
        className="rounded-md border-gray-300 shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50 w-full lg:w-auto"
        value={value || ""}
        onChange={(e) => {
          setValue(e.target.value);
          onChange(e.target.value);
        }}
        placeholder={`${count} elementos...`}
      />
    </label>
  );
}

const FilterTable = (props) => {
  const { preGlobalFilteredRows, state, setGlobalFilter, headerGroups } = props;
  return (
    <div className="lg:flex lg:gap-x-2">
      <GlobalFilter
        preGlobalFilteredRows={preGlobalFilteredRows}
        globalFilter={state.globalFilter}
        setGlobalFilter={setGlobalFilter}
      />
      <div className="grid grid-cols-2 lg:grid-cols-4 sm:gap-2 ">
        {headerGroups.map((headerGroup) =>
          headerGroup.headers.map((column) =>
            column.Filter ? (
              <div
                className="col-span-2 sm:col-span-1 lg:col-span-1 mt-2 lg:mt-0 capitalize"
                key={column.id}
              >
                {column.render("Filter")}
              </div>
            ) : null
          )
        )}
      </div>
    </div>
  );
};

export default FilterTable;
