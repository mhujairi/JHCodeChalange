import { Counter } from "./components/Counter";
import { TopHashTags } from "./components/TopHashTags";
import { Home } from "./components/Home";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/TopHashtags',
        element: <TopHashTags />
    }
];

export default AppRoutes;
