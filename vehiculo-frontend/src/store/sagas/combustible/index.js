import { call, put, takeEvery } from "redux-saga/effects";
import { getCollection } from "../../api/admin/index";
import {
  combustibleIsFetching,
  combustibleRequestData,
  combustibleRequestDataSuccess,
  combustibleRequestError,
} from "../../slices/combustible/combustible";

function* getCollectionWorker(action) {
  yield put(combustibleIsFetching(true));
  try {
     const combustible = yield call(getCollection("combustible"));
    

    if (combustible && combustible.data.length !== 0) {
      yield put(combustibleRequestDataSuccess(combustible.data));
    }
  } catch (e) {
    yield put(combustibleRequestError(e));
  }
}

function* combustibleSaga() {
  yield takeEvery(combustibleRequestData, getCollectionWorker);
}

export default combustibleSaga;
