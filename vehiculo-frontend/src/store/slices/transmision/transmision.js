import { createSlice } from "@reduxjs/toolkit";

const sliceName = "transmision";

const initialState = {
  isFetchingData: false,
  data: [],
  errorMsg: "",
};

const transmisionSlice = createSlice({
  name: sliceName,
  initialState,
  reducers: {
    transmisionRequestData(state, action) {},
    transmisionIsFetching(state, action) {
      state.isFetchingData = action.payload;
    },
    transmisionRequestError(state, action) {
      state.isFetchingData = false;
      state.errorMsg = action.payload;
    },
    transmisionRequestDataSuccess(state, action) {
      state.isFetchingData = false;
      state.data = action.payload.data;
    },
  },
});

const { actions, reducer } = transmisionSlice;

export const {
  transmisionRequestData,
  transmisionIsFetching,
  transmisionRequestError,
  transmisionRequestDataSuccess,
} = actions;

export default reducer;
