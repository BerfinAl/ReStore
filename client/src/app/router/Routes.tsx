import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
} from "react-router-dom";
import Home from "../../features/home/Home";
import Catalog from "../../features/catalog/Catalog";
import ProductDetails from "../../features/catalog/ProductDetails";
import About from "../../features/about/About";
import App from "../layout/App";
import Contact from "../../features/contact/Contact";

export const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<App />}>
      <Route index path="" element={<Home />} />
      <Route path="catalog" element={<Catalog />} />
      <Route path="catalog/:id" element={<ProductDetails />} />
      <Route path="about" element={<About />} />
      <Route path="contact" element={<Contact />} />
    </Route>
  )
);
