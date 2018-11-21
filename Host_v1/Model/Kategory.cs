namespace Host_v1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Media.Imaging;

    [Table("Kategory")]
    public partial class Kategory: INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kategory()
        {
            Number = new HashSet<Number>();
        }

        [Key]
        public int ID_type { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        [StringLength(300)]
        public string description { get; set; }

        public int capacity { get; set; }

        public int cost { get; set; }

        public byte[] photo { get; set; }
        [NotMapped]
        public string Name
        {
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
            get { return name; }
        }
        [NotMapped]
        public string Description
        {
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
            get { return description; }
        }
        [NotMapped]
        public int Capacity
        {
            set
            {
                capacity = value;
                OnPropertyChanged("Capacity");
            }
            get { return capacity; }
        }
        [NotMapped]
        public int Cost
        {
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
            get { return cost; }
        }
        private Image ph;
        [NotMapped]
        public Image Photo
        {
            set
            {
                ph = value;
                MemoryStream ms = new MemoryStream();
                value.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                photo = ms.ToArray();

                //photo = value;
                OnPropertyChanged("Photo");
            }
            get
            {
                if (ph == null)
                {
                    MemoryStream ms = new MemoryStream(photo);
                    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                    ph = returnImage;
                }
                return ph;
                ////MemoryStream memorystream = new MemoryStream();
                ////memorystream.Write(photo, 0, (int)photo.Length);
                ////BitmapImage imgsource = new BitmapImage();
                ////imgsource.BeginInit();
                ////imgsource.StreamSource = memorystream;
                ////imgsource.EndInit();
                ////return imgsource;
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Number> Number { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        // public static byte[]  imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    return ms.ToArray();
        //}

        //public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);


        //    return returnImage;
        //}
    }
}
