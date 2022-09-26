import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { useDispatch, useSelector } from "react-redux";
import Button from "../../components/BaseButton";
import Modal from "../../components/BaseModal";
import Select from "../../components/BaseSelect";
import TextField from "../../components/BaseTextField";
import {
  vehiculoRequestCreate,
  vehiculoRequestUpdate,
} from "../../store/slices/vehiculo/vehiculo";

const CarForm = ({ open, setOpen, objectSelected }) => {
  const dispatch = useDispatch();

  const {
    combustibleReducer,
    marcaReducer,
    tipoVehiculoReducer,
    transmisionReducer,
  } = useSelector((state) => state);

  const data = objectSelected?.original;

  const { register, handleSubmit, setValue } = useForm();

  const onSubmit = (value) => {
    if (data) {
      value.id = data.id;
      dispatch(vehiculoRequestUpdate(value));
    } else dispatch(vehiculoRequestCreate(value));

    setOpen(false);
  };

  useEffect(() => {
    setValue("numeroPatente", data?.numeroPatente);
    setValue("numeroChasis", data?.numeroChasis);
    setValue("idMarca", data?.idMarca);
    setValue("modeloName", data?.modeloName);
    setValue("idTipoVehiculo", data?.idTipoVehiculo);
    setValue("IdCombustible", data?.idCombustible);
    setValue("idTransmision", data?.idTransmision);
  }, [data, setValue]);

  return (
    <Modal open={open} setOpen={setOpen} data={data} nameModal={"Vehiculo"}>
      <section aria-labelledby="options-heading" className="mt-2">
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="overflow-hidden">
            <div className="bg-white px-4 py-5 sm:p-6">
              <div className="grid grid-cols-6 gap-6">
                <div className="col-span-6 sm:col-span-3">
                  <TextField
                    label={"Patente"}
                    disabled={data?.numeroPatente}
                    register={register("numeroPatente", {
                      required: true,
                      max: 6,
                      min: 3,
                    })}
                  />
                </div>
                <div className="col-span-6 sm:col-span-3">
                  <TextField
                    label={"Numero Chasis"}
                    disabled={data?.numeroChasis}
                    register={register("numeroChasis", {
                      required: true,
                      max: 17,
                    })}
                  />
                </div>
                <div className="col-span-6 sm:col-span-3">
                  <Select
                    label={"Marca"}
                    data={marcaReducer.data}
                    register={register("idMarca", { required: true })}
                  />
                </div>
                <div className="col-span-6 sm:col-span-3">
                  <TextField
                    label={"Modelo"}
                    register={register("modeloName", { required: true })}
                  />
                </div>
                <div className="col-span-6 sm:col-span-6 lg:col-span-2">
                  <Select
                    label={"Tipo Vehiculo"}
                    data={tipoVehiculoReducer.data}
                    register={register("idTipoVehiculo", { required: true })}
                  />
                </div>
                <div className="col-span-6 sm:col-span-6 lg:col-span-2">
                  <Select
                    label={"Transmision"}
                    data={transmisionReducer.data}
                    register={register("idTransmision", { required: true })}
                  />
                </div>
                <div className="col-span-6 sm:col-span-6 lg:col-span-2">
                  <Select
                    label={"Combustible"}
                    data={combustibleReducer.data}
                    register={register("idCombustible", { required: true })}
                  />
                </div>
              </div>
            </div>
            <div className="bg-gray-50 px-4 py-3 text-right sm:px-6 ">
              <Button
                label="Guardar"
                type="submit"
                className="justify-center border-transparent text-white  bg-indigo-600 hover:bg-indigo-700 focus:ring-indigo-500"
              />
            </div>
          </div>
        </form>
      </section>
    </Modal>
  );
};

export default CarForm;
