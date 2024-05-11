using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.View;
using ISSLab.ViewModel;

namespace Tests.ViewModel
{
    internal class ChatFactoryTests
    {
        private ChatFactory chatFactory;

        [SetUp]
        public void SetUp()
        {
            chatFactory = new ChatFactory();
        }

        [Test]
        public void OurChat_CreateChatWasNeverCalled_ReturnsNull()
        {
            Assert.That(chatFactory.OurChat, Is.Null);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void OurChat_CreateChatHasBeenCalled_ReturnsAChat()
        {
            chatFactory.CreateChat(new ChatViewModel(new ISSLab.Model.User(), new ISSLab.Model.Post()));

            Assert.That(chatFactory.OurChat, Is.InstanceOf<Chat>());
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void CreateChat_Any_ReturnsAChat()
        {
            IChat returned = chatFactory.CreateChat(new ChatViewModel(new ISSLab.Model.User(), new ISSLab.Model.Post()));

            Assert.That(returned, Is.InstanceOf<Chat>());
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void CreateChat_Any_ChangesFactoriesChat()
        {
            IChat returned = chatFactory.CreateChat(new ChatViewModel(new ISSLab.Model.User(), new ISSLab.Model.Post()));

            Assert.That(chatFactory.OurChat, Is.InstanceOf<Chat>());
        }
    }
}
