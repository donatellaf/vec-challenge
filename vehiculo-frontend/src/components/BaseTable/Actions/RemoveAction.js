import { TrashIcon } from "@heroicons/react/24/solid";
import React, { useState, Fragment } from "react";
import { Dialog, Transition } from "@headlessui/react";
import { XMarkIcon } from "@heroicons/react/24/outline";
import { useDispatch } from "react-redux";
import { vehiculoRequestDelete } from "../../../store/slices/vehiculo/vehiculo";
import Button from "../../BaseButton";
import { TEXTS } from "../../../constants";

const RemoveAction = (props) => {
  const { objectSelected } = props;
  const dispatch = useDispatch();

  const [openModal, setOpenModal] = useState(false);

  const handlerRemove = () => {
    const remove = objectSelected.original.id;
    dispatch(vehiculoRequestDelete(remove));
    setOpenModal(false);
  };

  return (
    <>
      <button
        type="button"
        onClick={() => setOpenModal(true)}
        className="inline-flex items-center rounded-md border border-gray-300 bg-white px-2 py-2 text-sm font-medium text-gray-700 shadow-sm hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
      >
        <TrashIcon className="h-4 w-4 text-gray-500" aria-hidden="true" />
      </button>
      <Transition.Root show={openModal} as={Fragment}>
        <Dialog as="div" className="relative z-10" onClose={setOpenModal}>
          <Transition.Child
            as={Fragment}
            enter="ease-out duration-300"
            enterFrom="opacity-0"
            enterTo="opacity-100"
            leave="ease-in duration-200"
            leaveFrom="opacity-100"
            leaveTo="opacity-0"
          >
            <div className="fixed inset-0 hidden bg-gray-500 bg-opacity-75 transition-opacity md:block" />
          </Transition.Child>

          <div className="fixed inset-0 z-10 overflow-y-auto">
            <div className="flex min-h-full items-stretch justify-center text-center md:items-center md:px-2 lg:px-4">
              <Transition.Child
                as={Fragment}
                enter="ease-out duration-300"
                enterFrom="opacity-0 translate-y-4 md:translate-y-0 md:scale-95"
                enterTo="opacity-100 translate-y-0 md:scale-100"
                leave="ease-in duration-200"
                leaveFrom="opacity-100 translate-y-0 md:scale-100"
                leaveTo="opacity-0 translate-y-4 md:translate-y-0 md:scale-95"
              >
                <Dialog.Panel className="flex w-full transform text-left text-base transition md:my-8 md:max-w-2xl md:px-4 lg:max-w-lg">
                  <div className="relative flex w-full items-center overflow-hidden bg-white px-4 pt-14 pb-8 shadow-2xl sm:px-6 sm:pt-8 md:p-6 lg:p-8">
                    <button
                      type="button"
                      className="absolute top-4 right-4 text-gray-400 hover:text-gray-500 sm:top-8 sm:right-6 md:top-6 md:right-6 lg:top-8 lg:right-8"
                      onClick={() => setOpenModal(false)}
                    >
                      <XMarkIcon className="h-6 w-6" aria-hidden="true" />
                    </button>

                    <div className="grid w-full grid-cols-1 items-start gap-y-8 gap-x-6 sm:grid-cols-12 lg:gap-x-8">
                      <div className="sm:col-span-8 lg:col-span-12">
                        <h2 className="text-2xl font-bold text-gray-900 sm:pr-12">
                          {TEXTS.ELIMINAR}
                        </h2>
                        <section
                          aria-labelledby="options-heading"
                          className="mt-4"
                        >
                          {`Seguro que desea eliminar patente
                          ${objectSelected?.original?.numeroPatente} ?`}
                          <div className="bg-gray-50 px-4 py-3 text-right sm:px-6 mt-2 ">
                            <Button
                              label={TEXTS.ACEPTAR}
                              onClick={handlerRemove}
                              type="submit"
                              className="border-transparent bg-red-600 hover:bg-red-700 focus:ring-red-500 text-white"
                            />
                          </div>
                        </section>
                      </div>
                    </div>
                  </div>
                </Dialog.Panel>
              </Transition.Child>
            </div>
          </div>
        </Dialog>
      </Transition.Root>
    </>
  );
};

export default RemoveAction;
