import { combineReducers } from "redux";

import combustibleReducer from "./slices/combustible/combustible";
import marcaReducer from "./slices/marca/marca";
import tipoVehiculoReducer from "./slices/tipoVehiculo/tipoVehiculo";
import transmisionReducer from "./slices/transmision/transmision";
import vehiculoReducer from "./slices/vehiculo/vehiculo";

const appReducer = combineReducers({
  combustibleReducer,
  marcaReducer,
  tipoVehiculoReducer,
  transmisionReducer,
  vehiculoReducer,
});

const rootReducer = (state, action) => {
  if (action.type === "destroy_session") state = undefined;

  return appReducer(state, action);
};

export default rootReducer;
