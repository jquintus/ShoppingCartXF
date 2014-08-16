using Newtonsoft.Json;
using ShoppingCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Services
{
    public class ProductLoader : IProductLoader
    {
        #region public const string JSON_DATA = "..."

        public const string JSON_DATA =
            @"[
    {
        'Name': 'pede',
        'Description': 'Nulla facilisi. Sed neque. Sed eget lacus. Mauris non dui nec',
        'Category': 'Movies',
        'Price': '345.02',
        'ProductCode': 'YZ7089D',
        'Rating': 3
    },
    {
        'Name': 'Sed',
        'Description': 'gravida. Praesent eu nulla at sem molestie sodales. Mauris blandit enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate',
        'Category': 'Gripples',
        'Price': '199.84',
        'ProductCode': 'GE4046H',
        'Rating': 2
    },
    {
        'Name': 'Nulla',
        'Description': 'egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec',
        'Category': 'Gripples',
        'Price': '142.52',
        'ProductCode': 'FB1712O',
        'Rating': 5
    },
    {
        'Name': 'feugiat nec',
        'Description': 'Praesent luctus. Curabitur egestas nunc sed libero. Proin sed turpis nec mauris blandit mattis. Cras eget nisi dictum augue malesuada malesuada. Integer id magna et ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor arcu. Vestibulum ut eros',
        'Category': 'Food',
        'Price': '227.34',
        'ProductCode': 'NI4739O',
        'Rating': 2
    },
    {
        'Name': 'at risus',
        'Description': 'tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus',
        'Category': 'Movies',
        'Price': '85.98',
        'ProductCode': 'HF2182L',
        'Rating': 2
    },
    {
        'Name': 'enim consequat purus',
        'Description': 'Suspendisse sed dolor. Fusce mi lorem, vehicula et, rutrum eu, ultrices sit amet, risus. Donec nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus',
        'Category': 'Bar',
        'Price': '61.03',
        'ProductCode': 'BP9758V',
        'Rating': 2
    },
    {
        'Name': 'purus',
        'Description': 'lobortis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Mauris ut quam vel sapien imperdiet ornare. In faucibus. Morbi',
        'Category': 'Foo',
        'Price': '227.31',
        'ProductCode': 'PM3350K',
        'Rating': 2
    },
    {
        'Name': 'nibh. Donec',
        'Description': 'eu tellus. Phasellus elit pede, malesuada vel, venenatis vel, faucibus id, libero. Donec consectetuer mauris id sapien. Cras dolor dolor, tempus non, lacinia at, iaculis quis, pede',
        'Category': 'Food',
        'Price': '363.71',
        'ProductCode': 'EL4474K',
        'Rating': 5
    },
    {
        'Name': 'Nullam scelerisque',
        'Description': 'dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed eu nibh vulputate mauris sagittis placerat. Cras dictum ultricies ligula. Nullam enim. Sed nulla ante, iaculis nec, eleifend non, dapibus rutrum, justo. Praesent luctus. Curabitur egestas nunc sed libero',
        'Category': 'Flargs',
        'Price': '72.93',
        'ProductCode': 'DK3730B',
        'Rating': 3
    },
    {
        'Name': 'sagittis lobortis',
        'Description': 'sem. Nulla interdum. Curabitur dictum. Phasellus in felis. Nulla tempor augue ac',
        'Category': 'Toys',
        'Price': '206.00',
        'ProductCode': 'KT0240D',
        'Rating': 5
    },
    {
        'Name': 'sit',
        'Description': 'mauris. Integer sem elit, pharetra ut, pharetra sed, hendrerit a, arcu. Sed et libero. Proin mi. Aliquam gravida mauris ut mi. Duis risus odio, auctor',
        'Category': 'Food',
        'Price': '265.30',
        'ProductCode': 'JT0534N',
        'Rating': 1
    },
    {
        'Name': 'tellus eu',
        'Description': 'a ultricies adipiscing, enim mi tempor lorem, eget mollis lectus pede et risus. Quisque libero lacus, varius et, euismod et, commodo at, libero',
        'Category': 'Food',
        'Price': '376.93',
        'ProductCode': 'BN6425P',
        'Rating': 4
    },
    {
        'Name': 'velit in aliquet',
        'Description': 'non magna. Nam ligula elit, pretium et, rutrum non, hendrerit id, ante. Nunc mauris sapien, cursus in, hendrerit consectetuer, cursus et, magna. Praesent interdum ligula eu enim. Etiam',
        'Category': 'Flargs',
        'Price': '397.94',
        'ProductCode': 'UI4197L',
        'Rating': 4
    },
    {
        'Name': 'eleifend nec, malesuada',
        'Description': 'turpis non enim. Mauris quis turpis vitae purus gravida sagittis. Duis gravida. Praesent eu nulla at sem molestie sodales. Mauris blandit enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate',
        'Category': 'Toys',
        'Price': '327.55',
        'ProductCode': 'IA9256G',
        'Rating': 2
    },
    {
        'Name': 'aliquet',
        'Description': 'placerat. Cras dictum ultricies ligula. Nullam enim. Sed nulla ante, iaculis nec, eleifend non, dapibus rutrum',
        'Category': 'Bar',
        'Price': '42.43',
        'ProductCode': 'PC3350I',
        'Rating': 2
    },
    {
        'Name': 'nibh. Phasellus',
        'Description': 'Duis at lacus. Quisque purus sapien, gravida non, sollicitudin a, malesuada id, erat. Etiam vestibulum massa',
        'Category': 'Flargs',
        'Price': '293.58',
        'ProductCode': 'OF8412M',
        'Rating': 1
    },
    {
        'Name': 'a odio semper',
        'Description': 'sem, vitae aliquam eros turpis non enim. Mauris quis turpis vitae purus gravida sagittis. Duis gravida. Praesent eu nulla at sem molestie sodales. Mauris blandit enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate eu, odio. Phasellus at augue id ante',
        'Category': 'Gripples',
        'Price': '345.98',
        'ProductCode': 'OI4153O',
        'Rating': 5
    },
    {
        'Name': 'in',
        'Description': 'pede, nonummy ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu elit. Nulla facilisi. Sed neque. Sed eget lacus. Mauris non dui nec urna suscipit nonummy. Fusce fermentum fermentum arcu. Vestibulum ante ipsum primis',
        'Category': 'Food',
        'Price': '100.60',
        'ProductCode': 'SU8380A',
        'Rating': 4
    },
    {
        'Name': 'arcu',
        'Description': 'tincidunt orci quis lectus. Nullam suscipit, est ac facilisis facilisis, magna tellus faucibus leo, in lobortis tellus justo sit amet nulla. Donec non justo. Proin non massa non ante bibendum ullamcorper. Duis cursus, diam at pretium',
        'Category': 'Toys',
        'Price': '26.80',
        'ProductCode': 'KG2803W',
        'Rating': 2
    },
    {
        'Name': 'amet ante. Vivamus',
        'Description': 'enim. Sed nulla ante, iaculis nec, eleifend non, dapibus rutrum, justo. Praesent luctus. Curabitur egestas nunc sed libero. Proin sed turpis nec mauris blandit mattis. Cras eget nisi dictum',
        'Category': 'Flargs',
        'Price': '135.07',
        'ProductCode': 'HM9056E',
        'Rating': 1
    },
    {
        'Name': 'dapibus',
        'Description': 'imperdiet dictum magna. Ut tincidunt orci quis lectus. Nullam suscipit, est ac facilisis facilisis, magna tellus faucibus leo, in lobortis tellus justo sit amet nulla. Donec non justo. Proin non massa non ante bibendum ullamcorper. Duis cursus, diam at pretium aliquet',
        'Category': 'Movies',
        'Price': '221.28',
        'ProductCode': 'GL4491N',
        'Rating': 4
    },
    {
        'Name': 'id, mollis',
        'Description': 'fermentum vel, mauris. Integer sem elit, pharetra ut, pharetra sed, hendrerit a, arcu. Sed et libero. Proin mi. Aliquam gravida mauris ut mi. Duis risus odio, auctor vitae, aliquet nec, imperdiet nec, leo. Morbi neque tellus, imperdiet non, vestibulum nec, euismod in, dolor',
        'Category': 'Flargs',
        'Price': '66.31',
        'ProductCode': 'ZG8854G',
        'Rating': 4
    },
    {
        'Name': 'Vestibulum',
        'Description': 'dolor sit amet, consectetuer adipiscing elit. Etiam laoreet, libero et tristique pellentesque, tellus',
        'Category': 'Gripples',
        'Price': '146.19',
        'ProductCode': 'XX5601C',
        'Rating': 1
    },
    {
        'Name': 'arcu eu odio',
        'Description': 'sed, est. Nunc laoreet lectus quis massa. Mauris vestibulum, neque sed dictum eleifend, nunc risus varius orci, in consequat enim diam vel arcu. Curabitur ut odio vel est tempor bibendum. Donec felis orci, adipiscing non, luctus sit amet, faucibus ut, nulla. Cras eu tellus',
        'Category': 'Flargs',
        'Price': '238.28',
        'ProductCode': 'MX0208T',
        'Rating': 1
    },
    {
        'Name': 'parturient montes',
        'Description': 'ligula eu enim. Etiam imperdiet dictum magna. Ut tincidunt orci quis lectus. Nullam suscipit, est ac facilisis facilisis, magna tellus faucibus leo, in lobortis tellus',
        'Category': 'Foo',
        'Price': '253.82',
        'ProductCode': 'TK7580S',
        'Rating': 2
    },
    {
        'Name': 'sodales nisi',
        'Description': 'Morbi metus. Vivamus euismod urna. Nullam lobortis quam a felis ullamcorper viverra. Maecenas iaculis aliquet diam. Sed diam lorem, auctor quis, tristique ac, eleifend vitae, erat. Vivamus nisi. Mauris nulla. Integer urna. Vivamus molestie dapibus',
        'Category': 'Gripples',
        'Price': '208.57',
        'ProductCode': 'PS7114P',
        'Rating': 5
    },
    {
        'Name': 'enim',
        'Description': 'vel, venenatis vel, faucibus id, libero. Donec consectetuer mauris id sapien. Cras dolor dolor, tempus non, lacinia at, iaculis quis, pede. Praesent eu dui. Cum sociis',
        'Category': 'Foo',
        'Price': '227.73',
        'ProductCode': 'JN2928A',
        'Rating': 3
    },
    {
        'Name': 'nonummy ipsum non',
        'Description': 'rhoncus. Nullam velit dui, semper et, lacinia vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam rutrum lorem ac risus. Morbi metus. Vivamus euismod urna. Nullam lobortis quam a felis ullamcorper viverra. Maecenas iaculis aliquet diam. Sed diam lorem, auctor quis, tristique ac, eleifend vitae, erat. Vivamus nisi. Mauris',
        'Category': 'Foo',
        'Price': '39.28',
        'ProductCode': 'MQ1925S',
        'Rating': 3
    },
    {
        'Name': 'turpis',
        'Description': 'ligula eu enim. Etiam imperdiet dictum magna. Ut tincidunt orci quis lectus. Nullam suscipit, est ac facilisis facilisis, magna tellus faucibus',
        'Category': 'Flargs',
        'Price': '49.93',
        'ProductCode': 'QI9917K',
        'Rating': 4
    },
    {
        'Name': 'erat volutpat. Nulla',
        'Description': 'habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce aliquet magna a neque. Nullam ut nisi a odio semper cursus. Integer mollis. Integer tincidunt aliquam arcu. Aliquam ultrices iaculis odio. Nam interdum enim non nisi. Aenean eget metus. In',
        'Category': 'Toys',
        'Price': '168.83',
        'ProductCode': 'ZN8465R',
        'Rating': 3
    },
    {
        'Name': 'natoque penatibus et',
        'Description': 'vulputate eu, odio. Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum eu',
        'Category': 'Gripples',
        'Price': '156.35',
        'ProductCode': 'KS2711I',
        'Rating': 1
    },
    {
        'Name': 'ligula',
        'Description': 'Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed eu nibh vulputate mauris sagittis placerat. Cras dictum ultricies ligula. Nullam enim. Sed nulla ante, iaculis nec, eleifend non, dapibus rutrum, justo',
        'Category': 'Toys',
        'Price': '140.35',
        'ProductCode': 'QU0780C',
        'Rating': 1
    },
    {
        'Name': 'eu tellus. Phasellus',
        'Description': 'nulla. Cras eu tellus eu augue porttitor interdum. Sed auctor odio a purus. Duis elementum, dui quis accumsan convallis, ante lectus convallis est, vitae sodales nisi magna sed',
        'Category': 'Bar',
        'Price': '316.06',
        'ProductCode': 'KP5616I',
        'Rating': 3
    },
    {
        'Name': 'magna',
        'Description': 'neque venenatis lacus. Etiam bibendum fermentum metus. Aenean sed pede nec ante blandit viverra. Donec tempus, lorem fringilla ornare placerat, orci lacus vestibulum lorem, sit amet ultricies sem magna nec quam. Curabitur vel lectus. Cum sociis natoque penatibus',
        'Category': 'Foo',
        'Price': '179.35',
        'ProductCode': 'JA2868Z',
        'Rating': 3
    },
    {
        'Name': 'Duis gravida',
        'Description': 'ullamcorper, velit in aliquet lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu ac orci',
        'Category': 'Foo',
        'Price': '146.06',
        'ProductCode': 'UG7956E',
        'Rating': 5
    },
    {
        'Name': 'nibh',
        'Description': 'molestie pharetra nibh. Aliquam ornare, libero at auctor ullamcorper, nisl arcu',
        'Category': 'Toys',
        'Price': '208.31',
        'ProductCode': 'DR9666R',
        'Rating': 1
    },
    {
        'Name': 'nostra, per',
        'Description': 'nisi a odio semper cursus. Integer mollis. Integer tincidunt aliquam arcu. Aliquam ultrices iaculis odio. Nam interdum enim non nisi. Aenean eget metus. In nec orci. Donec nibh. Quisque nonummy ipsum non arcu. Vivamus sit amet risus. Donec egestas. Aliquam nec enim. Nunc ut erat. Sed',
        'Category': 'Foo',
        'Price': '295.72',
        'ProductCode': 'DX6943O',
        'Rating': 4
    },
    {
        'Name': 'nec, eleifend',
        'Description': 'sem magna nec quam. Curabitur vel lectus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec dignissim magna a tortor. Nunc commodo auctor velit. Aliquam nisl. Nulla eu neque pellentesque massa lobortis ultrices. Vivamus rhoncus. Donec',
        'Category': 'Food',
        'Price': '271.93',
        'ProductCode': 'VY6210U',
        'Rating': 4
    },
    {
        'Name': 'aliquam adipiscing',
        'Description': 'metus vitae velit egestas lacinia. Sed congue, elit sed consequat auctor, nunc nulla vulputate dui, nec tempus',
        'Category': 'Toys',
        'Price': '257.67',
        'ProductCode': 'JE6004G',
        'Rating': 3
    },
    {
        'Name': 'tempus non',
        'Description': 'tincidunt congue turpis. In condimentum. Donec at arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede blandit congue. In scelerisque scelerisque dui. Suspendisse ac metus vitae velit egestas lacinia. Sed congue, elit sed consequat auctor, nunc',
        'Category': 'Flargs',
        'Price': '1.58',
        'ProductCode': 'KG0795V',
        'Rating': 2
    },
    {
        'Name': 'Suspendisse',
        'Description': 'nunc sed libero. Proin sed turpis nec mauris blandit mattis. Cras eget nisi dictum augue malesuada malesuada. Integer id magna et ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor arcu. Vestibulum ut eros non enim commodo hendrerit. Donec porttitor tellus non magna',
        'Category': 'Bar',
        'Price': '380.67',
        'ProductCode': 'FC7974K',
        'Rating': 1
    },
    {
        'Name': 'ut',
        'Description': 'eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam',
        'Category': 'Flargs',
        'Price': '341.12',
        'ProductCode': 'WB9189C',
        'Rating': 2
    },
    {
        'Name': 'adipiscing',
        'Description': 'tempor diam dictum sapien. Aenean massa. Integer vitae nibh. Donec',
        'Category': 'Gripples',
        'Price': '178.83',
        'ProductCode': 'CE0392T',
        'Rating': 1
    },
    {
        'Name': 'Aliquam ornare, libero',
        'Description': 'eu lacus. Quisque imperdiet, erat nonummy ultricies ornare, elit elit fermentum risus, at fringilla purus mauris a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut ipsum',
        'Category': 'Gripples',
        'Price': '155.44',
        'ProductCode': 'QR0270Q',
        'Rating': 1
    },
    {
        'Name': 'ligula',
        'Description': 'Phasellus ornare. Fusce mollis. Duis sit amet diam eu dolor egestas rhoncus. Proin nisl sem, consequat nec, mollis',
        'Category': 'Flargs',
        'Price': '304.65',
        'ProductCode': 'TO4410Q',
        'Rating': 5
    },
    {
        'Name': 'Morbi metus',
        'Description': 'enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate eu, odio. Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum eu, eleifend nec, malesuada ut, sem. Nulla interdum. Curabitur dictum. Phasellus in felis. Nulla tempor augue ac ipsum. Phasellus vitae mauris sit amet lorem',
        'Category': 'Foo',
        'Price': '236.13',
        'ProductCode': 'DY4081H',
        'Rating': 5
    },
    {
        'Name': 'consectetuer',
        'Description': 'Quisque ornare tortor at risus. Nunc ac sem ut dolor dapibus gravida. Aliquam tincidunt, nunc ac mattis ornare, lectus ante dictum mi, ac mattis velit justo nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non leo. Vivamus',
        'Category': 'Food',
        'Price': '221.98',
        'ProductCode': 'CY7692Y',
        'Rating': 3
    },
    {
        'Name': 'nec, eleifend non',
        'Description': 'tincidunt adipiscing. Mauris molestie pharetra nibh. Aliquam ornare, libero at auctor ullamcorper, nisl arcu iaculis enim, sit amet ornare lectus justo eu arcu. Morbi sit amet massa. Quisque porttitor eros nec tellus. Nunc',
        'Category': 'Gripples',
        'Price': '152.48',
        'ProductCode': 'RD6768Q',
        'Rating': 2
    },
    {
        'Name': 'Donec fringilla. Donec',
        'Description': 'orci, consectetuer euismod est arcu ac orci. Ut semper pretium neque. Morbi quis urna. Nunc quis arcu vel quam dignissim pharetra. Nam ac nulla',
        'Category': 'Movies',
        'Price': '141.06',
        'ProductCode': 'RJ0369C',
        'Rating': 4
    },
    {
        'Name': 'Nulla aliquet',
        'Description': 'placerat, augue. Sed molestie. Sed id risus quis diam luctus lobortis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Mauris ut quam vel sapien imperdiet ornare. In faucibus',
        'Category': 'Flargs',
        'Price': '94.28',
        'ProductCode': 'XX3387A',
        'Rating': 1
    },
    {
        'Name': 'id',
        'Description': 'Proin ultrices. Duis volutpat nunc sit amet metus. Aliquam erat volutpat. Nulla facilisis. Suspendisse',
        'Category': 'Bar',
        'Price': '350.26',
        'ProductCode': 'UV5111B',
        'Rating': 3
    },
    {
        'Name': 'neque. Morbi',
        'Description': 'egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna, malesuada vel, convallis in, cursus et, eros. Proin ultrices. Duis volutpat nunc sit amet metus. Aliquam erat volutpat. Nulla facilisis',
        'Category': 'Flargs',
        'Price': '361.85',
        'ProductCode': 'IA5064H',
        'Rating': 1
    },
    {
        'Name': 'lobortis. Class',
        'Description': 'elit pede, malesuada vel, venenatis vel, faucibus id, libero. Donec consectetuer mauris id sapien. Cras dolor dolor, tempus non, lacinia at, iaculis quis, pede. Praesent eu dui. Cum sociis',
        'Category': 'Flargs',
        'Price': '320.47',
        'ProductCode': 'QN6567V',
        'Rating': 1
    },
    {
        'Name': 'lacus. Mauris non',
        'Description': 'Proin non massa non ante bibendum ullamcorper. Duis cursus, diam at pretium aliquet, metus urna convallis erat, eget tincidunt dui augue eu tellus. Phasellus elit pede, malesuada vel, venenatis vel, faucibus id, libero. Donec consectetuer mauris id sapien. Cras dolor dolor, tempus non, lacinia',
        'Category': 'Toys',
        'Price': '221.76',
        'ProductCode': 'OL7946T',
        'Rating': 2
    },
    {
        'Name': 'lorem, luctus ut',
        'Description': 'Sed id risus quis diam luctus lobortis. Class aptent taciti sociosqu ad litora torquent per conubia nostra',
        'Category': 'Bar',
        'Price': '351.61',
        'ProductCode': 'ZE2887A',
        'Rating': 4
    },
    {
        'Name': 'orci, consectetuer euismod',
        'Description': 'est, congue a, aliquet vel, vulputate eu, odio. Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum eu, eleifend nec, malesuada ut',
        'Category': 'Toys',
        'Price': '91.77',
        'ProductCode': 'CW3508A',
        'Rating': 1
    },
    {
        'Name': 'dignissim. Maecenas ornare',
        'Description': 'quam. Curabitur vel lectus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec dignissim magna a tortor. Nunc commodo auctor velit. Aliquam',
        'Category': 'Foo',
        'Price': '227.39',
        'ProductCode': 'XP1985L',
        'Rating': 3
    },
    {
        'Name': 'id, mollis nec',
        'Description': 'tellus eu augue porttitor interdum. Sed auctor odio a purus. Duis elementum, dui quis accumsan convallis, ante lectus convallis est, vitae sodales nisi magna sed dui. Fusce aliquam, enim nec tempus scelerisque, lorem ipsum sodales purus, in molestie tortor nibh sit amet orci. Ut sagittis lobortis',
        'Category': 'Toys',
        'Price': '335.87',
        'ProductCode': 'ZH8689A',
        'Rating': 2
    },
    {
        'Name': 'non leo',
        'Description': 'Fusce fermentum fermentum arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Phasellus ornare. Fusce mollis. Duis sit amet diam eu dolor egestas rhoncus. Proin nisl sem, consequat nec, mollis vitae, posuere at, velit. Cras lorem lorem, luctus ut, pellentesque eget, dictum placerat',
        'Category': 'Toys',
        'Price': '91.02',
        'ProductCode': 'XM0287S',
        'Rating': 4
    },
    {
        'Name': 'quam',
        'Description': 'Quisque ac libero nec ligula consectetuer rhoncus. Nullam velit dui',
        'Category': 'Foo',
        'Price': '148.68',
        'ProductCode': 'PZ2620G',
        'Rating': 3
    },
    {
        'Name': 'nec, mollis',
        'Description': 'sit amet massa. Quisque porttitor eros nec tellus. Nunc lectus pede, ultrices a, auctor non, feugiat nec, diam. Duis mi enim, condimentum eget, volutpat ornare, facilisis eget, ipsum. Donec sollicitudin adipiscing ligula. Aenean gravida nunc',
        'Category': 'Gripples',
        'Price': '157.25',
        'ProductCode': 'TY6398B',
        'Rating': 1
    },
    {
        'Name': 'Aliquam',
        'Description': 'lectus convallis est, vitae sodales nisi magna sed dui. Fusce aliquam, enim nec tempus scelerisque, lorem ipsum sodales purus, in molestie tortor nibh sit amet orci. Ut sagittis lobortis mauris. Suspendisse aliquet molestie tellus. Aenean egestas hendrerit neque',
        'Category': 'Toys',
        'Price': '220.57',
        'ProductCode': 'PO5923V',
        'Rating': 4
    },
    {
        'Name': 'ipsum nunc id',
        'Description': 'Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna, malesuada',
        'Category': 'Food',
        'Price': '313.42',
        'ProductCode': 'HB1397Z',
        'Rating': 5
    },
    {
        'Name': 'ultricies dignissim lacus',
        'Description': 'arcu ac orci. Ut semper pretium neque. Morbi quis urna. Nunc quis arcu vel quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In condimentum. Donec at arcu. Vestibulum ante ipsum primis in faucibus orci luctus',
        'Category': 'Toys',
        'Price': '333.39',
        'ProductCode': 'CR3580C',
        'Rating': 2
    },
    {
        'Name': 'quis accumsan',
        'Description': 'amet risus. Donec egestas. Aliquam nec enim. Nunc ut erat. Sed nunc est, mollis',
        'Category': 'Gripples',
        'Price': '72.94',
        'ProductCode': 'GK7039G',
        'Rating': 1
    },
    {
        'Name': 'nisl. Quisque',
        'Description': 'Sed auctor odio a purus. Duis elementum, dui quis accumsan convallis, ante lectus convallis est, vitae sodales nisi magna sed dui. Fusce aliquam, enim nec tempus scelerisque, lorem ipsum sodales purus, in',
        'Category': 'Movies',
        'Price': '10.99',
        'ProductCode': 'SG3572B',
        'Rating': 3
    },
    {
        'Name': 'Vivamus non',
        'Description': 'amet nulla. Donec non justo. Proin non massa non ante bibendum ullamcorper. Duis cursus, diam at pretium aliquet, metus urna convallis erat, eget tincidunt dui augue eu tellus. Phasellus elit pede',
        'Category': 'Foo',
        'Price': '273.68',
        'ProductCode': 'HQ0002K',
        'Rating': 5
    },
    {
        'Name': 'sem eget',
        'Description': 'gravida mauris ut mi. Duis risus odio, auctor vitae, aliquet nec, imperdiet nec, leo. Morbi neque tellus, imperdiet non, vestibulum nec, euismod in, dolor. Fusce feugiat. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aliquam',
        'Category': 'Foo',
        'Price': '75.22',
        'ProductCode': 'HF7136Y',
        'Rating': 4
    },
    {
        'Name': 'ut nisi',
        'Description': 'ornare sagittis felis. Donec tempor, est ac mattis semper, dui lectus rutrum urna, nec luctus felis purus ac tellus. Suspendisse sed',
        'Category': 'Movies',
        'Price': '42.75',
        'ProductCode': 'CK4239R',
        'Rating': 1
    },
    {
        'Name': 'sem. Nulla',
        'Description': 'cursus luctus, ipsum leo elementum sem, vitae aliquam eros turpis non enim. Mauris quis turpis vitae purus gravida sagittis. Duis gravida. Praesent eu nulla at sem',
        'Category': 'Bar',
        'Price': '311.72',
        'ProductCode': 'TL7155D',
        'Rating': 1
    },
    {
        'Name': 'vulputate, lacus. Cras',
        'Description': 'metus urna convallis erat, eget tincidunt dui augue eu tellus. Phasellus elit pede, malesuada vel, venenatis vel, faucibus id, libero. Donec consectetuer mauris id sapien. Cras dolor dolor, tempus non, lacinia at, iaculis quis, pede',
        'Category': 'Flargs',
        'Price': '381.56',
        'ProductCode': 'LC4990K',
        'Rating': 2
    },
    {
        'Name': 'diam',
        'Description': 'vitae, erat. Vivamus nisi. Mauris nulla. Integer urna. Vivamus molestie dapibus ligula. Aliquam erat volutpat. Nulla dignissim. Maecenas ornare egestas ligula. Nullam feugiat placerat velit. Quisque varius. Nam porttitor scelerisque',
        'Category': 'Toys',
        'Price': '271.97',
        'ProductCode': 'ZX0838U',
        'Rating': 3
    },
    {
        'Name': 'libero. Donec consectetuer',
        'Description': 'sapien imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas',
        'Category': 'Gripples',
        'Price': '193.04',
        'ProductCode': 'IK1768C',
        'Rating': 4
    },
    {
        'Name': 'justo. Praesent',
        'Description': 'id magna et ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor arcu. Vestibulum ut eros non enim commodo hendrerit. Donec porttitor tellus non magna',
        'Category': 'Toys',
        'Price': '262.94',
        'ProductCode': 'QT2951U',
        'Rating': 2
    },
    {
        'Name': 'tristique senectus et',
        'Description': 'torquent per conubia nostra, per inceptos hymenaeos. Mauris ut quam vel sapien imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis ac arcu. Nunc mauris. Morbi non sapien molestie',
        'Category': 'Gripples',
        'Price': '222.12',
        'ProductCode': 'TB9282Q',
        'Rating': 2
    },
    {
        'Name': 'nisl',
        'Description': 'ante blandit viverra. Donec tempus, lorem fringilla ornare placerat, orci lacus vestibulum lorem',
        'Category': 'Gripples',
        'Price': '46.43',
        'ProductCode': 'OH0411Y',
        'Rating': 5
    },
    {
        'Name': 'pede',
        'Description': 'eu augue porttitor interdum. Sed auctor odio a purus. Duis elementum, dui quis accumsan convallis, ante lectus convallis est, vitae sodales nisi magna sed dui. Fusce aliquam, enim nec tempus scelerisque, lorem ipsum sodales purus, in molestie tortor nibh sit amet orci. Ut sagittis lobortis mauris',
        'Category': 'Gripples',
        'Price': '241.27',
        'ProductCode': 'XC7418N',
        'Rating': 3
    },
    {
        'Name': 'natoque penatibus et',
        'Description': 'fringilla purus mauris a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam',
        'Category': 'Bar',
        'Price': '309.64',
        'ProductCode': 'SS2234Q',
        'Rating': 2
    },
    {
        'Name': 'eget',
        'Description': 'ornare placerat, orci lacus vestibulum lorem, sit amet ultricies sem magna nec quam. Curabitur vel lectus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec dignissim magna a tortor. Nunc',
        'Category': 'Movies',
        'Price': '292.99',
        'ProductCode': 'GU3657E',
        'Rating': 2
    },
    {
        'Name': 'tempor lorem',
        'Description': 'quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam',
        'Category': 'Movies',
        'Price': '157.46',
        'ProductCode': 'SB2563N',
        'Rating': 5
    },
    {
        'Name': 'Fusce diam nunc',
        'Description': 'aliquet. Proin velit. Sed malesuada augue ut lacus. Nulla tincidunt, neque vitae semper egestas, urna justo faucibus lectus, a sollicitudin orci sem eget massa. Suspendisse',
        'Category': 'Gripples',
        'Price': '23.64',
        'ProductCode': 'TI4430P',
        'Rating': 5
    },
    {
        'Name': 'eu sem',
        'Description': 'Aenean egestas hendrerit neque. In ornare sagittis felis. Donec tempor, est ac mattis semper, dui lectus rutrum urna, nec luctus felis purus ac tellus. Suspendisse sed dolor. Fusce mi lorem',
        'Category': 'Food',
        'Price': '122.27',
        'ProductCode': 'VX3610U',
        'Rating': 5
    },
    {
        'Name': 'tincidunt',
        'Description': 'ultrices a, auctor non, feugiat nec, diam. Duis mi enim, condimentum eget, volutpat ornare, facilisis eget, ipsum. Donec sollicitudin adipiscing ligula. Aenean gravida nunc sed pede. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel',
        'Category': 'Gripples',
        'Price': '105.06',
        'ProductCode': 'NC9716Q',
        'Rating': 1
    },
    {
        'Name': 'quam',
        'Description': 'senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna, malesuada vel, convallis',
        'Category': 'Flargs',
        'Price': '346.41',
        'ProductCode': 'PT4082H',
        'Rating': 4
    },
    {
        'Name': 'in aliquet lobortis',
        'Description': 'et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur consequat, lectus sit amet luctus vulputate, nisi sem semper erat, in consectetuer ipsum nunc id enim. Curabitur massa. Vestibulum accumsan neque et nunc. Quisque ornare tortor at risus',
        'Category': 'Foo',
        'Price': '87.42',
        'ProductCode': 'ZK2276W',
        'Rating': 4
    },
    {
        'Name': 'nec tempus',
        'Description': 'diam. Sed diam lorem, auctor quis, tristique ac, eleifend vitae, erat. Vivamus nisi. Mauris nulla. Integer urna. Vivamus molestie dapibus ligula. Aliquam erat volutpat. Nulla dignissim. Maecenas ornare egestas ligula. Nullam feugiat placerat velit',
        'Category': 'Foo',
        'Price': '171.39',
        'ProductCode': 'BL6146P',
        'Rating': 3
    },
    {
        'Name': 'sollicitudin',
        'Description': 'nonummy ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu elit. Nulla facilisi. Sed neque. Sed eget lacus. Mauris non dui nec urna suscipit nonummy. Fusce fermentum fermentum arcu',
        'Category': 'Toys',
        'Price': '34.74',
        'ProductCode': 'QM9705W',
        'Rating': 2
    },
    {
        'Name': 'sit amet',
        'Description': 'Nunc quis arcu vel quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In condimentum. Donec at arcu. Vestibulum ante ipsum primis in faucibus orci luctus',
        'Category': 'Gripples',
        'Price': '112.76',
        'ProductCode': 'UC4331T',
        'Rating': 5
    },
    {
        'Name': 'ultrices iaculis odio',
        'Description': 'sem elit, pharetra ut, pharetra sed, hendrerit a, arcu. Sed et libero. Proin mi. Aliquam gravida mauris ut mi. Duis risus odio, auctor vitae, aliquet nec, imperdiet nec, leo. Morbi neque tellus, imperdiet non, vestibulum nec, euismod in',
        'Category': 'Flargs',
        'Price': '161.35',
        'ProductCode': 'TI4779R',
        'Rating': 3
    },
    {
        'Name': 'nibh. Aliquam',
        'Description': 'id sapien. Cras dolor dolor, tempus non, lacinia at, iaculis quis, pede. Praesent eu dui. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean eget',
        'Category': 'Food',
        'Price': '85.81',
        'ProductCode': 'MR7750M',
        'Rating': 2
    },
    {
        'Name': 'adipiscing',
        'Description': 'a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut',
        'Category': 'Toys',
        'Price': '12.64',
        'ProductCode': 'GH9744F',
        'Rating': 5
    },
    {
        'Name': 'ut odio vel',
        'Description': 'magna. Suspendisse tristique neque venenatis lacus. Etiam bibendum fermentum metus. Aenean sed pede nec ante blandit viverra. Donec tempus, lorem fringilla ornare placerat, orci lacus vestibulum lorem, sit amet ultricies sem magna nec quam',
        'Category': 'Foo',
        'Price': '277.61',
        'ProductCode': 'DV4074K',
        'Rating': 3
    },
    {
        'Name': 'nisi. Aenean eget',
        'Description': 'non, hendrerit id, ante. Nunc mauris sapien, cursus in, hendrerit consectetuer, cursus et, magna. Praesent interdum ligula eu enim. Etiam imperdiet dictum magna. Ut tincidunt orci quis lectus. Nullam suscipit, est ac facilisis',
        'Category': 'Toys',
        'Price': '97.57',
        'ProductCode': 'PC8048P',
        'Rating': 3
    },
    {
        'Name': 'amet ante. Vivamus',
        'Description': 'conubia nostra, per inceptos hymenaeos. Mauris ut quam vel sapien imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis ac arcu. Nunc mauris. Morbi non sapien molestie orci tincidunt adipiscing. Mauris molestie pharetra nibh. Aliquam ornare, libero at auctor ullamcorper, nisl',
        'Category': 'Gripples',
        'Price': '285.02',
        'ProductCode': 'SB9269J',
        'Rating': 3
    },
    {
        'Name': 'Phasellus fermentum',
        'Description': 'sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed eu nibh vulputate mauris sagittis placerat. Cras dictum ultricies ligula. Nullam enim. Sed nulla ante, iaculis nec, eleifend',
        'Category': 'Toys',
        'Price': '334.02',
        'ProductCode': 'VR2091A',
        'Rating': 5
    },
    {
        'Name': 'justo. Praesent',
        'Description': 'Duis elementum, dui quis accumsan convallis, ante lectus convallis est, vitae sodales nisi magna sed dui. Fusce aliquam, enim nec tempus',
        'Category': 'Flargs',
        'Price': '268.52',
        'ProductCode': 'WT1813F',
        'Rating': 2
    },
    {
        'Name': 'pede. Praesent',
        'Description': 'enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate eu, odio. Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum eu, eleifend nec, malesuada ut',
        'Category': 'Foo',
        'Price': '98.36',
        'ProductCode': 'UO5699Z',
        'Rating': 2
    },
    {
        'Name': 'nibh. Donec est',
        'Description': 'eu, odio. Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum eu, eleifend nec, malesuada ut, sem. Nulla interdum. Curabitur dictum. Phasellus in felis. Nulla tempor augue ac ipsum. Phasellus vitae mauris sit amet lorem semper auctor. Mauris vel',
        'Category': 'Gripples',
        'Price': '251.54',
        'ProductCode': 'LK4616N',
        'Rating': 5
    },
    {
        'Name': 'nibh',
        'Description': 'lectus ante dictum mi, ac mattis velit justo nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non leo. Vivamus nibh dolor, nonummy ac, feugiat non, lobortis quis, pede. Suspendisse dui',
        'Category': 'Foo',
        'Price': '131.12',
        'ProductCode': 'DU1216T',
        'Rating': 5
    },
    {
        'Name': 'sodales',
        'Description': 'aliquet lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu ac orci. Ut semper pretium neque',
        'Category': 'Movies',
        'Price': '164.72',
        'ProductCode': 'KM0387Z',
        'Rating': 2
    },
    {
        'Name': 'Yoga:  Choose Your Own Adventure',
        'Description' : 'An exciting adventure awaits you at every pose.  Watch as the story unfolds as you choose between your favorite yoga positions including Eagle Pose, Childs Pose, Warrior II, and so much more.',
        'Category': 'Books',
        'ImageUrl' : 'http://www.womenshealthmag.com/files/wh6_uploads/2014/05/30/childs_pose_425.jpg',
        'Price' :'14.99',
        'ProductCode' : 'bk_yoga_4567',
        'Rating' :'4'
    },
    {
        'Category': 'Books',
        'Name': 'Pride and Prejudice and Zombies',
        'Description' : 'This is a book',
        'Price' :'6.99',
        'ProductCode' : '343422333',
        'Rating' :'3'
    },
    {
        'Category': 'Books',
        'Name': 'Something Wicked This Way Comes ',
        'Description' : 'This is a book',
        'Price' :'4.99',
        'ProductCode' : '343422334',
        'Rating' :'2'
    },
    {
        'Category': 'Books',
        'Name': 'The Hitchhikers Guide to the Galaxy',
        'Description' : 'This is a book',
        'Price' :'14.99',
        'ProductCode' : '343422336',
        'Rating' :'4'
    },
    {
        'Category': 'Books',
        'Name': 'The Curious Incident of the Dog in the Night-Time ',
        'Description' : 'This is a book',
        'Price' :'3.99',
        'ProductCode' : '343422348',
        'Rating' :'2'
    },
    {
        'Category': 'Books',
        'Name': 'The Hollow Chocolate Bunnies of the Apocalypse ',
        'Description' : 'This is a book',
        'Price' :'8.99',
        'ProductCode' : '343422832',
        'Rating' :'1'
    },
    {
        'Category': 'Books',
        'Name': 'Eats, Shoots & Leaves: The Zero Tolerance Approach to Punctuation ',
        'Description' : 'This is a book',
        'Price' :'7.99',
        'ProductCode' : '344422332',
        'Rating' :'1'
    },
    {
        'Category': 'Books',
        'Name': 'Are You There, Vodka? Its Me, Chelsea ',
        'Description' : 'This is a book',
        'Price' :'3.99',
        'ProductCode' : '243422332',
        'Rating' :'1'
    },
    {
        'Category': 'Books',
        'Name': 'The Unbearable Lightness of Being',
        'Description' : 'This is a book',
        'Price' :'18.99',
        'ProductCode' : '343522332',
        'Rating' :'1'
    },
    {
        'Category': 'Books',
        'Name': 'Midnight in the Garden of Good and Evil',
        'Description' : 'This is a book',
        'Price' :'19.99',
        'ProductCode' : '393422332',
        'Rating' :'3'
    },
    {
        'Category': 'Books',
        'Name': 'The Earth, My Butt, and Other Big Round Things ',
        'Description' : 'This is a book',
        'Price' :'2.99',
        'ProductCode' : '313422332',
        'Rating' :'2'
    },
    {
        'Category': 'Books',
        'Name': 'Stop Dressing Your Six-Year-Old Like a Skank: A Slightly Tarnished Southern Belles Words of Wisdom ',
        'Description' : 'This is a book',
        'Price' :'28.99',
        'ProductCode' : '334322332',
        'Rating' :'1'
    },
    {
        'Category': 'Books',
        'Name': 'Cloudy With a Chance of Meatballs ',
        'Description' : 'This is a book',
        'Price' :'4.99',
        'ProductCode' : '949422332',
        'Rating' :'3'
    },
    {
        'Category': 'Books',
        'Name': 'The Perks of Being a Wallflower ',
        'Description' : 'This is a book',
        'Price' :'5.99',
        'ProductCode' : '343417998',
        'Rating' :'2'
    },
    {
        'Category': 'Books',
        'Name': 'The Long Dark Tea-Time of the Soul',
        'Description' : 'This is a book',
        'Price' :'9.99',
        'ProductCode' : '343424675',
        'Rating' :'2'
    },
    {
        'Category': 'Books',
        'Name': 'An Arsonists Guide To Writers Homes In New England ',
        'Description' : 'This is a book',
        'Price' :'8.99',
        'ProductCode' : '343454755',
        'Rating' :'5'
    },
    {
        'Category': 'Books',
        'Name': 'A Heartbreaking Work of Staggering Genius ',
        'Description' : 'This is a book',
        'Price' :'48.99',
        'ProductCode' : '343654655',
        'Rating' :'1'
    },
    {
        'Category': 'Books',
        'Name': 'Alexander and the Terrible, Horrible, No Good, Very Bad Day ',
        'Description' : 'This is a book',
        'Price' :'4.99',
        'ProductCode' : '343886978',
        'Rating' :'5'
    },
    {
        'Category': 'Books',
        'Name': 'John Dies at the End',
        'Description' : 'This is a book',
        'Price' :'3.99',
        'ProductCode' : '344816270',
        'Rating' :'4'
    },
    {
        'Category': 'Books',
        'Name': 'The Gordonston Ladies Dog Walking Club ',
        'Description' : 'This is a book',
        'Price' :'6.99',
        'ProductCode' : '348998084',
        'Rating' :'1'
    },
    {
        'Category': 'Books',
        'Name': 'The Zombie Survival Guide: Complete Protection from the Living Dead ',
        'Description' : 'This is a book',
        'Price' :'5.99',
        'ProductCode' : '358523327',
        'Rating' :'4'
    },
    {
        'Category': 'Books',
        'Name': 'So Long, and Thanks for All the Fish',
        'Description' : 'This is a book',
        'Price' :'4.99',
        'ProductCode' : '361311403',
        'Rating' :'4'
    },
    {
        'Category': 'Books',
        'Name': 'I Still Miss My Man But My Aim Is Getting Better ',
        'Description' : 'This is a book',
        'Price' :'2.99',
        'ProductCode' : '343507180',
        'Rating' :'1'
    },
    {
        'Category': 'Books',
        'Name': 'When You Are Engulfed in Flames ',
        'Description' : 'This is a book',
        'Price' :'1.99',
        'ProductCode' : '343846572',
        'Rating' :'4'
    },
    {
        'Category': 'Books',
        'Name': 'Extremely Loud and Incredibly Close ',
        'Description' : 'This is a book',
        'Price' :'34.99',
        'ProductCode' : '346392012',
        'Rating' :'2'
    },
    {
        'Category': 'Books',
        'Name': 'The Devil Wears Prada',
        'Description' : 'This is a book',
        'Price' :'5.99',
        'ProductCode' : '388766866',
        'Rating' :'2'
    },
    {
        'Category': 'Books',
        'Name': 'The Guernsey Literary and Potato Peel Pie Society ',
        'Description' : 'This is a book',
        'Price' :'23.99',
        'ProductCode' : '1386346614',
        'Rating' :'2'
    },
    {
        'Category': 'Books',
        'Name': 'I Have No Mouth and I Must Scream ',
        'Description' : 'This is a book',
        'Price' :'5.99',
        'ProductCode' : '932901274',
        'Rating' :'2'
    }
]";

        #endregion public const string JSON_DATA = "..."

        #region private List<string> ImgurIds = new ...

        private Queue<string> ImgurIds = new Queue<string>(new List<string>(){
"lrMwxGJ",
"V5W78FG",
"C1gR4cb",
"7W2KahS",
"yAKwAmU",
"GUrRNpM",
"yZQjzuf",
"B6EDSjS",
"N5ctFW8",
"d2yBEDq",
"OcQhrlC",
"yJhOy1g",
"QT4BAU5",
"G4mW2eC",
"4zQGj0O",
"oMUYlw6",
"a852qNy",
"Q7uE1Qk",
"9HzqtJS",
"1anWq6J",
"Ol5LPeN",
"aUWnhW9",
"xZDG2MS",
"jTZbmKb",
"Zk8hoac",
"u5MyfD2",
"L2E2uIO",
"Lj3wxWE",
"oDGuK4s",
"q9a4cPQ",
"ncanQx9",
"lztC9Bq",
"MbdOkH6",
"qz6RF3J",
"tF0pHbc",
"YN16svr",
"WIDO7cj",
"U9IsbrH",
"nNKJOtI",
"AysY4qp",
"fDkrRWZ",
"1ElXaIW",
"c2LkHdK",
"VFMHe7n",
"RJfMRyU",
"nekp7oP",
"m3dHceE",
"knSdnMi",
"0ioO206",
"1q3TXNU",
"f4H8mVq",
"Zt3obhU",
"ITl061S",
"vlrjAqR",
"3xYK188",
"ctUG9Sf",
"eZgg9oI",
"FbES506",
"85G8msY",
"FYDyGIR",
"zJOCfyS",
"GGWAmqL",
"SEWxJoF",
"neVjOoF",
"rEySJjC",
"1cmALPW",
"h3WuVDk",
"DxJ7wZU",
"riy9iM5",
"yCFwFyG",
"kAEwwvM",
"FAsfsHP",
"n9lCO17",
"wE1TmoX",
"YwiBHXL",
"Zn7jSpI",
"qAs1ZhW",
"NRAbD1v",
"UaVQ53g",
"gcR3jba",
"6TXdomA",
"LqXRnZn",
"dihQPNM",
"ZsZuvhT",
"Uyt68TO",
"sGc5glu",
"8ivKcY2",
"zoNVWVU",
"T28puQo",
"lViUNN7",
"C09w2xl",
"TxnpfRV",
"vnlqbm6",
"OqMhCHq",
"xyxdwcj",
"0F1YDYW",
"Blsfc8o",
"ysCKkKt",
"Ci7Mwdw",
"Q9dRWs0",
"522CFGv",
"OCVPrlW",
"c2ZBCHX",
"wQcJ8sg",
"XJGygHt",
"Otk3Xia",
"934VUBq",
"8StO76q",
"tueGgET",
"LMy1vvg",
"b0Wd68u",
"EoTUgsp",
"Dd1T1kr",
"Q8UcCKK",
"gjkWvyL",
"JbaebRE",
"pZyCPuU",
"e82kj04",
"rMnin4q",
"IC0Y2a4",
"OYRGdDc",
"XUHsf55",
"fGUGw5Y",
"CAewIWS",
"O7T7fWM",
"6s8abnF",
"eZKDnlg",
"OUH4Ouh",
"jETV64h",
"AjuJNF0",
"mbPmS7W",
"0sE4AR4",
"AZCDj8H",
"TEIKlQw",
"w1TR1IX",
"fxZj4EH",
"3umn4s0",
"fkbM5iC",
"a7TCMDR",
"v8Dzuie",
"2xgqNWO",
"j9bdOJK",
"Yhs2r0N",
"NeW2m71",
"ntaB2Y6",
"CBcQYyE",
"QnyXvzY",
"uLXjqdg",
"wLPHyel",
"Efu4Jbw",
"cikDjcs",
"QSlZNoW",
"kgjnmpZ",
"0ZIw9oU",
"DeHyLRo",
"iH7j3p6",
"EFBjKC5",
"LyThWRu",
"zRQhSNj",
"EhMglhc",
"m75cfb4",
"uY8qHLK",
"hRrr4S1",
"Kkwi1Tc",
"k6xQob7",
"iK2Cq6G",
"bE9Jdb3",
"HYJsocj",
"odntcJM",
"iejfQME",
"vnVpQsj",
"C0fpArc",
"lU58hH4",
"xqE4hKe",
"8OVZt0G",
"raPvUF7",
"4xcRogN",
"pwhGkHl",
"0SdFuVU",
"8LsGTCN",
"V2dDPMa",
"VFZZz9g",
"1OdxeHb",
"NxJGW0e",
"AgqyWAu",
"Gs6QjkG",
"dossAH9",
"XI0oU7W",
"DM0FiX3",
"EYi4RJR",
"YTkiU7B",
"bqnNoaZ",
"HjQpPxi",
"YBq2hNb",
"v04H2iU",
"Q5Rp999",
"pVZVlYH",
"zwEoea9",
"GRR41gZ",
"6DhMohM",
"02k6agT",
"CbVmqUs",
"7SJmWJE",
"nyHrQlx",
"KD0fPN8",
"5Mxvve5",
"14A8khV",
"3Li7lYG",
"BsjSFrx",
"aKtrhf4",
"86N1G7M",
"XstaXFO",
"sz1Yz3J",
"MUCf66J",
"LAx1F3j",
"ny0nb0E",
"Qb8DoRI",
"8x7OGFN",
"JKSCgnP",
"JjclqdP",
"X9hT7As",
"PBAJCLF",
"9xyPvVl",
"4aqxZvb",
"WGpBqBi",
"4B5hZR0",
"DshhS8z",
"jSNSGTy",
"4AUoPLf",
"xOfvYdu",
"Lx9PR9b",
"LnxHL6G",
"Xz2J8zx",
"EomQ01n",
"sPWkgEs",
"8ryyNuo",
"PTUB218",
"TGC1yRR",
"ocHPQiw",
"9ekqGku",
"tQsuNJ5",
"kqIuzPz",
"Rucyi1T",
"8X2uQay",
"Oi1a6kk",
"KH8A4J1",
"cwH9pTG",
"JoeQjLx",
"2CJB2TZ",
"HJrMyGQ",
"MJLZzBz",
"i3RpNBp",
"goz85gJ",
"c64YOl7",
"WRf6cya",
"ZIAXJWG",
"O6DWtlA",
"0jLCyo4",
"DPB1Nop",
"i6rCyLj",
"jpWTQpb",
"pNiB8G9",
"kZ7bjXT",
"vS8CeU8",
"6zweh83",
"JW4RrKy",
"SvlieAr",
"ssy4z6V",
"DrDl8p7",
"qTMND3v",
"da61Ore",
"SAV6co7",
"h9tjEc7",
"5Cfrx43",
"aOOUUYO",
"fL9e8FW",
"IhygNUy",
"sqQbstW",
"m7tISJF",
"gk8AyIg",
"vyxIxCQ",
"YYeLRQo",
"Y1JQfUl",
"MvhA5mZ",
"32Wt84s",
"k24atEQ",
"pIsRiVw",
"P4I0Dc5",
"lDZv46w",
"c9GovMf",
"SjJP41H",
"iv80n3L",
"PfkFbQd",
"8f7tw6u",
"XOU6LLj",
"lx67bxK",
"CanxDqO",
"bpaMxgh",
"Kt68GdA",
"O2HsHmV",
"vVSt2qe",
"KNkhXL1",
"JVmCD86",
"YQskqCU",
"kSLQpXS",
"hBfB5eI",
"MloU1fP",
"UCbJr7y",
"BMhIpoz",
"H6SaCrZ",
"KIVrASz",
"YEiIpQo",
"goCkiRU",
"DicVIU6",
"Zd85lxg",
"0sqjPnE",
"xcoxzq2",
"8xStnry",
"M7glWMi",
"cmwJ92D",
"P9LMEy4",
"3rb89aH",
"MrIfgll",
"h8PNvTF",
"i7uqDGv",
"1VLv6ji",
"3sGlntT",
"MyMIhRk",
"WSukjgS",
"mPTYvJv",
"5fWWnpX",
"4ZkmmwA",
"2JCwqdI",
"z9WbpeA",
"2yRTpuz",
"GOnBkVX",
"W5bOG7Z",
"709L5xN",
"NvoEsW9",
"q1nVdhn",
"88ArT1Y",
"c6jjgWp",
"r4VFYIh",
"M6MTFGm",
"7Ak04i2",
"almnc83",
"qEcitvF",
"CV6lF4W",
"daoL2Pp",
"LdUlFZn",
"ahYfD3G",
"8YAajcM",
"yHI0LsO",
"2IV6qWK",
"VbhL5sR",
"hf1rCHx",
"9w7ucGe",
"38YI6QD",
"aHZGGg0",
"8JcuhEL",
"97V0LUj",
"us5QVxk",
"MNnUSXX",
"VXrPBMM",
"xBptU6H",
"BcKSJR9",
"xmODz36",
"rVVLu0I",
"i4TYxar",
"qA7OHbZ",
"RTP24IZ",
"Sg7NFPY",
"H0p9Xcl",
"IebCU1s",
"1D6tKqE",
"hRD2YOO",
"ZhIJqvI",
"0V5tepQ",
"SgbZMBB",
"bQA0mcS",
"LwrCwUN",
"Rw4jmIe",
"FuWflZE",
"nxKNihU",
"Cjs3Ltm",
"0eE54Ep",
"np3f7Cf",
"EUtkP1Y",
"Q8opxCv",
"YoxXdxz",
"s9TZzE8",
});

        #endregion private Queue<string> ImgurIds = new ...

        public async Task<List<Item>> LoadProducts()
        {
            var items = JsonConvert.DeserializeObject<List<Item>>(JSON_DATA);
            foreach (var item in items)
            {
                UpdateItem(item, ImgurIds.Dequeue());
            }
            return await Task.FromResult(items);
        }

        private static void UpdateItem(Item item, string imgurId)
        {
            item.ImageUrl = string.Format("http://i.imgur.com/{0}.jpg", imgurId);
            item.IconUrl = string.Format("http://i.imgur.com/{0}s.jpg", imgurId);
        }
    }
}