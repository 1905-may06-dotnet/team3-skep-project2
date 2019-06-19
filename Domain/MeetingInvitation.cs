using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MeetingInvitation
    {
        public int mIID { get; set; }
        public int senderUID { get; set; }
        public int receiverUID { get; set; }
        public int mID { get; set; }

        public int SenderUID { get => mIID; set
            {
                if (String.IsNullOrEmpty(senderUID.ToString()))
                    throw new ArgumentException("Sender ID # cannot be empty.");

                senderUID = value;
            }
        }

        public int ReceiverUID { get => receiverUID; set
            {
                if(String.IsNullOrEmpty(receiverUID.ToString()))
                    throw new ArgumentException("Receiver ID # cannot be empty.");

                receiverUID = value;
            }
        }

        public int MID { get => mID; set
            {
                if(String.IsNullOrEmpty(mID.ToString()))
                    throw new ArgumentException("Meeting ID # cannot be empty.");

                mID = value;
            }
        }

    }
}
