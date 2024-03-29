import Header from "../components/Header";
import '../components/style/AboutNoAuth.css'

function AboutNoAuth() {
    return (
        <>
            <Header/>
            <div className="textBlockAbout">
                <p id="textAbout">
                        Добро пожаловать на страницу "О нас" сайта Netflix!
                    <br/> <br /> <br />
                        Мы - мировой лидер в области потокового онлайн-видео и развлечений. Наша цель - предоставить нашим
                        пользователям доступ к самым лучшим фильмам, сериалам, документальным фильмам и оригинальному контенту в любое время и в любом месте.
                    <br/> <br />
                        Netflix был основан в 1997 году в США и с тех пор стал одним из самых популярных и узнаваемых сервисов для потокового воспроизведения видео во всем мире. Мы работаем 
                        с ведущими студиями и создателями контента, чтобы предложить нашим пользователям самые свежие и захватывающие фильмы и сериалы. 
                    <br/> <br />
                        Наша команда стремится к постоянному совершенствованию сервиса и
                        удовлетворению потребностей наших пользователей. Мы гордимся нашими инновациями, включая рекомендации контента на основе ваших предпочтений, а также возможность
                        скачивать фильмы и сериалы, чтобы смотреть их без подключения к интернету. 
                    <br/> <br />
                        Благодаря нашему постоянному обновлению библиотеки контента, у вас всегда будет широкий
                        выбор развлечений на любой вкус. Присоединяйтесь к миллионам пользователей Netflix по всему миру и наслаждайтесь уникальным опытом просмотра кино и сериалов! 
                    <br/> <br /> <br />
                        С уважением, Команда Netflix.
                    </p>
            </div>
        </>
    )
}

export default AboutNoAuth;