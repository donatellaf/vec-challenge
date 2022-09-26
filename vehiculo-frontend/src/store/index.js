import { configureStore } from "@reduxjs/toolkit";
import createSagaMiddleware from "redux-saga";
import rootReducer from "./rootReducer";
import rootSaga from "./sagas";

const sagaMiddleware = createSagaMiddleware();

const middlewares = [];
middlewares.push(sagaMiddleware);

const store = configureStore({
  reducer: rootReducer,
  devTools: true,
  middleware: [...middlewares],
});
sagaMiddleware.run(rootSaga);

export default store;
