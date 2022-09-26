import { PencilIcon } from "@heroicons/react/20/solid";
import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import Button from "../../components/BaseButton";
import BaseTable, { SelectColumnFilter } from "../../components/BaseTable";
import Actions from "../../components/BaseTable/Actions";
import { TEXTS } from "../../constants";
import { combustibleRequestData } from "../../store/slices/combustible/combustible";
import { marcaRequestData } from "../../store/slices/marca/marca";
import { tipoVehiculoRequestData } from "../../store/slices/tipoVehiculo/tipoVehiculo";
import { transmisionRequestData } from "../../store/slices/transmision/transmision";
import { vehiculoRequestData } from "../../store/slices/vehiculo/vehiculo";
import Form from "./CarForm";

const Car = () => {
  const dispatch = useDispatch();
  const [open, setOpen] = useState(false);
  const [objectSelected, setObjectSelected] = useState(null);

  useEffect(() => {
    dispatch(combustibleRequestData());
    dispatch(marcaRequestData());
    dispatch(tipoVehiculoRequestData());
    dispatch(transmisionRequestData());
    dispatch(vehiculoRequestData());
  }, [dispatch]);

  const vehiculo = useSelector((state) => state.vehiculoReducer.data);

  const handleAddItem = () => {
    setObjectSelected(null);
    setOpen(true);
  };

  const data = React.useMemo(() => vehiculo, [vehiculo]);

  const columns = React.useMemo(
    () => [
      {
        Header: "marca",
        accessor: "marcaName",
        Filter: SelectColumnFilter,
        filter: "includes",
      },
      {
        Header: "modelo",
        accessor: "modeloName",
        Filter: SelectColumnFilter,
        filter: "includes",
      },
      {
        Header: "tipo",
        accessor: "tipoVehiculoName",
        Filter: SelectColumnFilter,
        filter: "includes",
      },
      {
        Header: "patente",
        accessor: "numeroPatente",
      },

      {
        Header: "chasis",
        accessor: "numeroChasis",
      },
      {
        Header: "transmision",
        accessor: "transmisionName",
        Filter: SelectColumnFilter,
        filter: "includes",
      },
      {
        Header: "Actions",
        accessor: "actions",
        Cell: (
          <Actions
            open={open}
            setOpen={setOpen}
            objectSelected={objectSelected}
          />
        ),
      },
    ],
    [objectSelected, open]
  );

  return (
    <div className="bg-white">
      <div>
        <main className="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
          <div className="sm:flex sm:items-center lg:justify-between pt-10 pb-6">
            <div className="min-w-0 flex-1">
              <h2 className="text-2xl font-bold leading-7 text-gray-900 sm:truncate sm:text-3xl sm:tracking-tight">
                {TEXTS.TITLE}
              </h2>
            </div>
            <div className="mt-5 flex lg:mt-0 lg:ml-4">
              <span className="sm:ml-3">
                <Button
                  label={TEXTS.AGREGAR}
                  onClick={handleAddItem}
                  Icon={PencilIcon}
                  iconClassname="-ml-1 mr-2 h-5 w-5 text-gray-500"
                  className="items-center border-gray-300 bg-white text-gray-700  hover:bg-gray-50  focus:ring-indigo-500"
                />
              </span>
            </div>
          </div>

          <section aria-labelledby="products-heading" className="pt-6 pb-24">
            <div className="grid grid-cols-1 gap-x-8 gap-y-10 lg:grid-cols-4">
              <div className="lg:col-span-8">
                <BaseTable
                  columns={columns}
                  data={data}
                  setObjectSelected={setObjectSelected}
                />
              </div>
            </div>
          </section>
        </main>
      </div>
      <Form open={open} setOpen={setOpen} objectSelected={objectSelected} />
    </div>
  );
};

export default Car;
